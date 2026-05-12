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
    public partial class UserManagementForm : Form
    {
        private readonly User _currentUser;
        private List<User> _users = new List<User>();

        public UserManagementForm(User currentUser)
        {
            _currentUser = currentUser;
            InitializeComponent();
            this.Text = "Управление пользователями";
            LoadUsers();
        }

        private void LoadUsers()
        {
            using var db = new AppDbContext();
            _users = db.Users
                .Include(u => u.Role)
                .OrderBy(u => u.UserId)
                .ToList();

            var view = _users.Select(u => new
            {
                u.UserId,
                u.Login,
                u.FullName,
                u.Email,
                Role = u.Role != null ? u.Role.RoleName : string.Empty
            }).ToList();

            dgvUsers.DataSource = null;
            dgvUsers.DataSource = view;

            if (dgvUsers.Columns["UserId"] != null)
                dgvUsers.Columns["UserId"].HeaderText = "ID";
            if (dgvUsers.Columns["Login"] != null)
                dgvUsers.Columns["Login"].HeaderText = "Логин";
            if (dgvUsers.Columns["FullName"] != null)
                dgvUsers.Columns["FullName"].HeaderText = "ФИО";
            if (dgvUsers.Columns["Email"] != null)
                dgvUsers.Columns["Email"].HeaderText = "E-mail";
            if (dgvUsers.Columns["Role"] != null)
                dgvUsers.Columns["Role"].HeaderText = "Роль";

            foreach (DataGridViewColumn col in dgvUsers.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private User? GetSelectedUser()
        {
            if (dgvUsers.CurrentRow == null) return null;
            int index = dgvUsers.CurrentRow.Index;
            if (index < 0 || index >= _users.Count) return null;
            return _users[index];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var form = new UserEditForm(_currentUser);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var user = GetSelectedUser();
            if (user == null)
            {
                MessageBox.Show("Выберите пользователя", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var form = new UserEditForm(_currentUser, user);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var user = GetSelectedUser();
            if (user == null)
            {
                MessageBox.Show("Выберите пользователя", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (user.UserId == _currentUser.UserId)
            {
                MessageBox.Show("Нельзя удалить самого себя", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"Удалить пользователя \"{user.Login}\"?",
                "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            using var db = new AppDbContext();

            // Проверим зависимости: проекты, баги, комментарии
            bool hasProjects = db.Projects.Any(p => p.OwnerUserId == user.UserId);
            bool hasAuthoredBugs = db.Bugs.Any(b => b.AuthorUserId == user.UserId);
            bool hasAssignedBugs = db.Bugs.Any(b => b.AssignedUserId == user.UserId);
            bool hasComments = db.Comments.Any(c => c.AuthorUserId == user.UserId);

            if (hasProjects || hasAuthoredBugs || hasAssignedBugs || hasComments)
            {
                MessageBox.Show(
                    "Нельзя удалить пользователя, у которого есть связанные " +
                    "проекты, баги или комментарии. Сначала переназначьте их.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var entity = db.Users.Find(user.UserId);
            if (entity == null)
            {
                MessageBox.Show("Пользователь уже удалён", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadUsers();
                return;
            }

            db.Users.Remove(entity);
            db.SaveChanges();

            ActivityLogger.Log(_currentUser.UserId, "Delete", "User", user.UserId,
                $"Удалён пользователь \"{user.Login}\"");

            LoadUsers();
            MessageBox.Show("Пользователь удалён", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
