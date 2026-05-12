using System;
using NETbugTracker.Data;
using NETbugTracker.Entities;

namespace NETbugTracker.Services
{
    /// <summary>
    /// Сервис для записи действий пользователей в журнал активности.
    /// </summary>
    public static class ActivityLogger
    {
        public static void Log(int userId, string actionType, string entityType,
            int? entityId = null, string description = "")
        {
            try
            {
                using var db = new AppDbContext();
                db.ActivityLogs.Add(new ActivityLog
                {
                    UserId = userId,
                    ActionType = actionType,
                    EntityType = entityType,
                    EntityId = entityId,
                    Description = description ?? string.Empty,
                    CreatedDate = DateTime.Now
                });
                db.SaveChanges();
            }
            catch
            {
                // Журналирование не должно прерывать основную операцию.
            }
        }
    }
}
