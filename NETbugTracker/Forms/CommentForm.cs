using System;
using System.Windows.Forms;
using NETbugTracker.Data;
using NETbugTracker.Entities;
using NETbugTracker.Services;

namespace NETbugTracker.Forms
{
    public partial class CommentForm : Form
    {
        private readonly User _currentUser;
        private readonly int _bugId;

        public CommentForm(User currentUser, int bugId)
        {
            _currentUser = currentUser;
            _bugId = bugId;
            InitializeComponent();
            this.Text = "Новый комментарий";
            AcceptButton = btnSave;
            CancelButton = btnCancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string text = txtComment.Text.Trim();
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Введите текст комментария", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var db = new AppDbContext();
            var comment = new Comment
            {
                BugId = _bugId,
                AuthorUserId = _currentUser.UserId,
                CommentText = text,
                CreatedDate = DateTime.Now
            };
            db.Comments.Add(comment);
            db.SaveChanges();

            ActivityLogger.Log(_currentUser.UserId, "Create", "Comment", comment.CommentId,
                $"Добавлен комментарий к багу #{_bugId}");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
