using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NETbugTracker.Entities;

namespace NETbugTracker.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=BugTrackerDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ========== НАСТРОЙКА ВНЕШНИХ КЛЮЧЕЙ ДЛЯ BUGS (БЕЗ КАСКАДНОГО УДАЛЕНИЯ) ==========
            // Это должно быть ПЕРВЫМ, до HasData

            // Связь с проектом - при удалении проекта удаляем баги (это нормально)
            modelBuilder.Entity<Bug>()
                .HasOne(b => b.Project)
                .WithMany(p => p.Bugs)
                .HasForeignKey(b => b.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // Связь с автором - НЕ удаляем баги при удалении пользователя
            modelBuilder.Entity<Bug>()
                .HasOne(b => b.AuthorUser)
                .WithMany()
                .HasForeignKey(b => b.AuthorUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Связь с исполнителем - НЕ удаляем баги при удалении пользователя
            modelBuilder.Entity<Bug>()
                .HasOne(b => b.AssignedUser)
                .WithMany()
                .HasForeignKey(b => b.AssignedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Связь со статусом - НЕ удаляем баги при удалении статуса
            modelBuilder.Entity<Bug>()
                .HasOne(b => b.Status)
                .WithMany()
                .HasForeignKey(b => b.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            // Связь с приоритетом - НЕ удаляем баги при удалении приоритета
            modelBuilder.Entity<Bug>()
                .HasOne(b => b.Priority)
                .WithMany()
                .HasForeignKey(b => b.PriorityId)
                .OnDelete(DeleteBehavior.Restrict);

            // ========== ЗАПОЛНЕНИЕ СПРАВОЧНИКОВ ==========

            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "Developer" },
                new Role { RoleId = 3, RoleName = "Tester" }
            );

            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = 1, StatusName = "New" },
                new Status { StatusId = 2, StatusName = "InProgress" },
                new Status { StatusId = 3, StatusName = "Review" },
                new Status { StatusId = 4, StatusName = "Closed" }
            );

            modelBuilder.Entity<Priority>().HasData(
                new Priority { PriorityId = 1, PriorityName = "Low" },
                new Priority { PriorityId = 2, PriorityName = "Medium" },
                new Priority { PriorityId = 3, PriorityName = "High" },
                new Priority { PriorityId = 4, PriorityName = "Critical" }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Login = "admin",
                    Password = "admin123",
                    FullName = "Администратор",
                    Email = "admin@bugtracker.com",
                    RoleId = 1
                }
            );

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Bug)
                .WithMany()
                .HasForeignKey(c => c.BugId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.AuthorUser)
                .WithMany()
                .HasForeignKey(c => c.AuthorUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
