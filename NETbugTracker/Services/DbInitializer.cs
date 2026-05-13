using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NETbugTracker.Data;
using NETbugTracker.Entities;

namespace NETbugTracker.Services
{
    /// <summary>
    /// Гарантирует, что база данных создана и заполнена базовыми данными
    /// (роли, статусы, приоритеты, учётная запись администратора).
    /// </summary>
    public static class DbInitializer
    {
        public static void EnsureCreatedAndSeeded()
        {
            using var db = new AppDbContext();
            try
            {
                db.Database.Migrate();
            }
            catch
            {
                // Если миграции по какой-то причине недоступны (например,
                // развёртывание выполнили вручную) — гарантируем хотя бы
                // наличие схемы.
                db.Database.EnsureCreated();
            }

            SeedRoles(db);
            SeedStatuses(db);
            SeedPriorities(db);
            SeedAdmin(db);
            db.SaveChanges();
        }

        private static void SeedRoles(AppDbContext db)
        {
            if (!db.Roles.Any(r => r.RoleId == 1))
                db.Roles.Add(new Role { RoleId = 1, RoleName = "Admin" });
            if (!db.Roles.Any(r => r.RoleId == 2))
                db.Roles.Add(new Role { RoleId = 2, RoleName = "Developer" });
            if (!db.Roles.Any(r => r.RoleId == 3))
                db.Roles.Add(new Role { RoleId = 3, RoleName = "Tester" });
        }

        private static void SeedStatuses(AppDbContext db)
        {
            if (!db.Statuses.Any(s => s.StatusId == 1))
                db.Statuses.Add(new Status { StatusId = 1, StatusName = "New" });
            if (!db.Statuses.Any(s => s.StatusId == 2))
                db.Statuses.Add(new Status { StatusId = 2, StatusName = "InProgress" });
            if (!db.Statuses.Any(s => s.StatusId == 3))
                db.Statuses.Add(new Status { StatusId = 3, StatusName = "Review" });
            if (!db.Statuses.Any(s => s.StatusId == 4))
                db.Statuses.Add(new Status { StatusId = 4, StatusName = "Closed" });
        }

        private static void SeedPriorities(AppDbContext db)
        {
            if (!db.Priorities.Any(p => p.PriorityId == 1))
                db.Priorities.Add(new Priority { PriorityId = 1, PriorityName = "Low" });
            if (!db.Priorities.Any(p => p.PriorityId == 2))
                db.Priorities.Add(new Priority { PriorityId = 2, PriorityName = "Medium" });
            if (!db.Priorities.Any(p => p.PriorityId == 3))
                db.Priorities.Add(new Priority { PriorityId = 3, PriorityName = "High" });
            if (!db.Priorities.Any(p => p.PriorityId == 4))
                db.Priorities.Add(new Priority { PriorityId = 4, PriorityName = "Critical" });
        }

        private static void SeedAdmin(AppDbContext db)
        {
            var admin = db.Users.FirstOrDefault(u => u.Login == "admin");
            if (admin == null)
            {
                db.Users.Add(new User
                {
                    Login = "admin",
                    Password = PasswordHasher.HashPassword("admin123"),
                    FullName = "Администратор",
                    Email = "admin@bugtracker.com",
                    RoleId = 1
                });
            }
            else if (!PasswordHasher.LooksHashed(admin.Password))
            {
                // Перевод сохранённого открытого пароля на хэш.
                admin.Password = PasswordHasher.HashPassword(admin.Password);
            }

            if (!db.Users.Any(u => u.Login == "dev"))
            {
                db.Users.Add(new User
                {
                    Login = "dev",
                    Password = PasswordHasher.HashPassword("dev123"),
                    FullName = "Разработчик Петров",
                    Email = "dev@example.com",
                    RoleId = 2
                });
            }

            if (!db.Users.Any(u => u.Login == "tester"))
            {
                db.Users.Add(new User
                {
                    Login = "tester",
                    Password = PasswordHasher.HashPassword("tester123"),
                    FullName = "Тестировщик Сидорова",
                    Email = "tester@example.com",
                    RoleId = 3
                });
            }
        }
    }
}
