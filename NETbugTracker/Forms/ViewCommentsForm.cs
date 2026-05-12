using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using NETbugTracker.Data;
using NETbugTracker.Entities;
using NETbugTracker.Services;

namespace NETbugTracker.Forms
{
    public partial class ViewCommentsForm : Form
    {
        private readonly User _currentUser;
        private readonly Bug _bug;
        private List<Comment> _comments = new List<Comment>();

        private bool IsAdmin => _currentUser.RoleId == 1;

        public ViewCommentsForm(User currentUser, Bug bug)
        {
            _currentUser = currentUser;
            _bug = bug;
            InitializeComponent();
            this.Text = $"Комментарии к багу #{bug.BugId}: {bug.Title}";
            lblBugTitle.Text = $"Баг: {bug.Title}";
            LoadComments();
        }

        private void LoadComments()
        {
            using var db = new AppDbContext();
            _comments = db.Comments
                .Include(c => c.AuthorUser)
                .Where(c => c.BugId == _bug.BugId)
                .OrderBy(c => c.CreatedDate)
                .ToList();

            var view = _comments.Select(c => new
            {
                c.CommentId,
                Автор = c.AuthorUser != null ? c.AuthorUser.FullName : "—",
                Дата = c.CreatedDate.ToString("g"),
                Текст = c.CommentText
            }).ToList();

            dgvComments.DataSource = null;
            dgvComments.DataSource = view;

            if (dgvComments.Columns["CommentId"] != null)
            {
                dgvComments.Columns["CommentId"].HeaderText = "ID";
                dgvComments.Columns["CommentId"].Width = 60;
            }
            if (dgvComments.Columns["Автор"] != null)
                dgvComments.Columns["Автор"].Width = 180;
            if (dgvComments.Columns["Дата"] != null)
                dgvComments.Columns["Дата"].Width = 140;
            if (dgvComments.Columns["Текст"] != null)
                dgvComments.Columns["Текст"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private Comment? GetSelectedComment()
        {
            if (dgvComments.CurrentRow == null) return null;
            int index = dgvComments.CurrentRow.Index;
            if (index < 0 || index >= _comments.Count) return null;
            return _comments[index];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var form = new CommentForm(_currentUser, _bug.BugId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadComments();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var comment = GetSelectedComment();
            if (comment == null)
            {
                MessageBox.Show("Выберите комментарий", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsAdmin && comment.AuthorUserId != _currentUser.UserId)
            {
                MessageBox.Show("Удалить можно только свой комментарий",
                    "Нет прав", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Удалить выбранный комментарий?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            using var db = new AppDbContext();
            var entity = db.Comments.Find(comment.CommentId);
            if (entity != null)
            {
                db.Comments.Remove(entity);
                db.SaveChanges();

                ActivityLogger.Log(_currentUser.UserId, "Delete", "Comment", comment.CommentId,
                    $"Удалён комментарий к багу #{_bug.BugId}");
            }
            LoadComments();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
