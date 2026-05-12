using System;
using System.Security.Cryptography;
using System.Text;

namespace NETbugTracker.Services
{
    /// <summary>
    /// Простое хэширование паролей SHA-256 + Base64.
    /// Достаточно для учебного проекта (дипломная работа).
    /// </summary>
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            if (password == null) password = string.Empty;
            using var sha256 = SHA256.Create();
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        public static bool VerifyPassword(string password, string storedValue)
        {
            if (string.IsNullOrEmpty(storedValue)) return false;

            string hashOfInput = HashPassword(password);
            if (hashOfInput == storedValue) return true;

            // Обратная совместимость со старыми записями, где пароль
            // хранился в открытом виде (на ранних этапах разработки).
            if (!LooksHashed(storedValue) && password == storedValue) return true;

            return false;
        }

        /// <summary>
        /// Эвристика: SHA-256 + Base64 даёт строку длиной 44 символа,
        /// заканчивающуюся на '='. Используется при миграции
        /// открытых паролей в хэшированную форму.
        /// </summary>
        public static bool LooksHashed(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;
            return value.Length == 44 && value.EndsWith("=");
        }
    }
}
