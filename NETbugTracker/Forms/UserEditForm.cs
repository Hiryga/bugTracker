using System;
using System.Linq;
using System.Windows.Forms;
using NETbugTracker.Data;
using NETbugTracker.Entities;
using NETbugTracker.Services;

namespace NETbugTracker.Forms
{
    public partial class UserEditForm : Form
    {
        private readonly User _currentUser;
        private readonly User? _editingUser;

        // Конструктор: создание нового пользователя
        public UserEditForm(User currentUser)
        {
            _currentUser = currentUser;
            _editingUser = null;
            InitializeComponent();
            this.Text = "Новый пользователь";
            LoadRoles();
            lblPasswordHint.Text = "Минимум 4 символа";
            AcceptButton = btnSave;
            CancelButton = btnCancel;
        }

        // Конструктор: редактирование пользователя
        public UserEditForm(User currentUser, User user) : this(currentUser)
        {
            _editingUser = user;
            this.Text = "Редактирование пользователя";

            txtLogin.Text = user.Login;
            txtFullName.Text = user.FullName;
            txtEmail.Text = user.Email;
            cmbRole.SelectedValue = user.RoleId;
            lblPasswordHint.Text = "Оставьте пустым, чтобы не менять";
        }

        private void LoadRoles()
        {
            using var db = new AppDbContext();
            cmbRole.DataSource = db.Roles.ToList();
            cmbRole.DisplayMember = "RoleName";
            cmbRole.ValueMember = "RoleId";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(login))
            {
                MessageBox.Show("Введите логин", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Введите ФИО", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbRole.SelectedValue == null)
            {
                MessageBox.Show("Выберите роль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int roleId = (int)cmbRole.SelectedValue;

            using var db = new AppDbContext();

            // Проверка уникальности логина
            bool loginTaken = _editingUser == null
                ? db.Users.Any(u => u.Login == login)
                : db.Users.Any(u => u.Login == login && u.UserId != _editingUser.UserId);
            if (loginTaken)
            {
                MessageBox.Show("Пользователь с таким логином уже существует",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_editingUser == null)
            {
                if (string.IsNullOrWhiteSpace(password) || password.Length < 4)
                {
                    MessageBox.Show("Введите пароль (минимум 4 символа)",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var user = new User
                {
                    Login = login,
                    Password = PasswordHasher.HashPassword(password),
                    FullName = fullName,
                    Email = email,
                    RoleId = roleId
                };
                db.Users.Add(user);
                db.SaveChanges();

                ActivityLogger.Log(_currentUser.UserId, "Create", "User", user.UserId,
                    $"Создан пользователь \"{user.Login}\"");
            }
            else
            {
                var user = db.Users.Find(_editingUser.UserId);
                if (user == null)
                {
                    MessageBox.Show("Пользователь не найден", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                user.Login = login;
                user.FullName = fullName;
                user.Email = email;
                user.RoleId = roleId;

                if (!string.IsNullOrWhiteSpace(password))
                {
                    if (password.Length < 4)
                    {
                        MessageBox.Show("Пароль должен содержать не менее 4 символов",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    user.Password = PasswordHasher.HashPassword(password);
                }

                db.SaveChanges();

                ActivityLogger.Log(_currentUser.UserId, "Edit", "User", user.UserId,
                    $"Изменён пользователь \"{user.Login}\"");
            }

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
