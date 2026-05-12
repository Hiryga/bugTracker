using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETbugTracker.Entities
{
    public class ActivityLog
    {
        [Key]
        public int LogId { get; set; }

        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ActionType { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string EntityType { get; set; } = string.Empty;

        public int? EntityId { get; set; }

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
    }
}
