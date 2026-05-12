using NETbugTracker.Data;
using NETbugTracker.Entities;
using NETbugTracker.Services;

namespace NETbugTracker
{
    public partial class LoginForm : Form
    {
        public User? CurrentUser { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var db = new AppDbContext();
            var user = db.Users.FirstOrDefault(u => u.Login == login);

            if (user == null || !PasswordHasher.VerifyPassword(password, user.Password))
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Если пароль ещё в открытом виде — перепишем на хэш.
            if (!PasswordHasher.LooksHashed(user.Password))
            {
                user.Password = PasswordHasher.HashPassword(password);
                db.SaveChanges();
            }

            ActivityLogger.Log(user.UserId, "Login", "User", user.UserId,
                $"Вход в систему пользователя \"{user.Login}\"");

            CurrentUser = user;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }
    }
}
