using NETbugTracker.Forms;
using NETbugTracker.Data;
using NETbugTracker.Entities;

namespace NETbugTracker
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using (var db = new AppDbContext())
            {
                var loginForm = new LoginForm();
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    var currentUser = loginForm.CurrentUser;
                    if (currentUser != null)
                    {
                        Application.Run(new MainForm(currentUser));
                    }
                    else
                    {
                        MessageBox.Show("Ошибка: пользователь не найден");
                        Application.Exit();
                    }
                }
                else
                {
                    Application.Exit();
                }

                // Проверяем, есть ли уже пользователи
                if (!db.Users.Any(u => u.Login == "dev"))
                {
                    db.Users.Add(new User
                    {
                        Login = "dev",
                        Password = "dev123",
                        FullName = "Разработчик Петров",
                        Email = "dev@example.com",
                        RoleId = 2  // Developer
                    });
                    db.Users.Add(new User
                    {
                        Login = "tester",
                        Password = "tester123",
                        FullName = "Тестировщик Сидорова",
                        Email = "tester@example.com",
                        RoleId = 3  // Tester
                    });
                    db.SaveChanges();
                }
            }

        }
    }
}