using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETbugTracker.Entities
{

    public class Bug
    {
        [Key]
        public int BugId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string StepsToReproduce { get; set; } = string.Empty;

        public int ProjectId { get; set; }
        public int AuthorUserId { get; set; }
        public int AssignedUserId { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project? Project { get; set; }

        [ForeignKey("AuthorUserId")]
        public virtual User? AuthorUser { get; set; }

        [ForeignKey("AssignedUserId")]
        public virtual User? AssignedUser { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status? Status { get; set; }

        [ForeignKey("PriorityId")]
        public virtual Priority? Priority { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}