using NETbugTracker.Forms;
using NETbugTracker.Services;

namespace NETbugTracker
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Гарантируем существование базы данных и наличие стартовых
            // данных (роли, статусы, приоритеты, учётная запись admin).
            try
            {
                DbInitializer.EnsureCreatedAndSeeded();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось инициализировать базу данных:\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var loginForm = new LoginForm();
            if (loginForm.ShowDialog() != DialogResult.OK || loginForm.CurrentUser == null)
            {
                Application.Exit();
                return;
            }

            Application.Run(new MainForm(loginForm.CurrentUser));
        }
    }
}
