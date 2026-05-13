using Microsoft.EntityFrameworkCore;
using NETbugTracker.Entities;

namespace NETbugTracker.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;
        public DbSet<Priority> Priorities { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<Bug> Bugs { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<ActivityLog> ActivityLogs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=BugTrackerDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ========== ВНЕШНИЕ КЛЮЧИ ДЛЯ BUGS ==========
            modelBuilder.Entity<Bug>()
                .HasOne(b => b.Project)
                .WithMany(p => p.Bugs)
                .HasForeignKey(b => b.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Bug>()
                .HasOne(b => b.AuthorUser)
                .WithMany()
                .HasForeignKey(b => b.AuthorUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bug>()
                .HasOne(b => b.AssignedUser)
                .WithMany()
                .HasForeignKey(b => b.AssignedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bug>()
                .HasOne(b => b.Status)
                .WithMany()
                .HasForeignKey(b => b.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bug>()
                .HasOne(b => b.Priority)
                .WithMany()
                .HasForeignKey(b => b.PriorityId)
                .OnDelete(DeleteBehavior.Restrict);

            // ========== ВНЕШНИЕ КЛЮЧИ ДЛЯ COMMENTS ==========
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Bug)
                .WithMany(b => b.Comments)
                .HasForeignKey(c => c.BugId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.AuthorUser)
                .WithMany()
                .HasForeignKey(c => c.AuthorUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // ========== ВНЕШНИЕ КЛЮЧИ ДЛЯ ACTIVITYLOG ==========
            modelBuilder.Entity<ActivityLog>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // ========== СПРАВОЧНИКИ ==========
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

            // Пароль "admin123" в виде SHA-256 + Base64.
            // Хэш предварительно вычислен, чтобы EF Core HasData оставался
            // детерминированным (иначе миграция будет регенерироваться
            // при каждом запуске).
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Login = "admin",
                    Password = "JAvlGPq9JyTdtvBO6x2llnRI1+gxwIyPqCKAn3THIKk=",
                    FullName = "Администратор",
                    Email = "admin@bugtracker.com",
                    RoleId = 1
                }
            );
        }
    }
}
