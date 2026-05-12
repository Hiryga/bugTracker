using System;
using System.Linq;
using System.Windows.Forms;
using NETbugTracker.Data;
using NETbugTracker.Entities;
using NETbugTracker.Services;

namespace NETbugTracker.Forms
{
    public partial class ChangePasswordForm : Form
    {
        private readonly User _currentUser;

        public ChangePasswordForm(User currentUser)
        {
            _currentUser = currentUser;
            InitializeComponent();
            this.Text = "Смена пароля";
            AcceptButton = btnSave;
            CancelButton = btnCancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(oldPassword) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Заполните все поля", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword.Length < 4)
            {
                MessageBox.Show("Новый пароль должен содержать не менее 4 символов",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Новый пароль и подтверждение не совпадают",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword == oldPassword)
            {
                MessageBox.Show("Новый пароль должен отличаться от старого",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var db = new AppDbContext();
            var user = db.Users.FirstOrDefault(u => u.UserId == _currentUser.UserId);
            if (user == null)
            {
                MessageBox.Show("Пользователь не найден", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            if (!PasswordHasher.VerifyPassword(oldPassword, user.Password))
            {
                MessageBox.Show("Старый пароль введён неверно", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            user.Password = PasswordHasher.HashPassword(newPassword);
            db.SaveChanges();

            _currentUser.Password = user.Password;

            ActivityLogger.Log(_currentUser.UserId, "ChangePassword", "User", user.UserId,
                "Пользователь сменил пароль");

            MessageBox.Show("Пароль успешно изменён", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

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
