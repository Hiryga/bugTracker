using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETbugTracker.Entities
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public string CommentText { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Внешние ключи
        public int BugId { get; set; }
        public int AuthorUserId { get; set; }

        // Навигационные свойства
        [ForeignKey("BugId")]
        public virtual Bug? Bug { get; set; }

        [ForeignKey("AuthorUserId")]
        public virtual User? AuthorUser { get; set; }
    }
}
