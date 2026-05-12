using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETbugTracker.Entities
{
    public class Priority
    {
        [Key]
        public int PriorityId { get; set; }
        public string PriorityName { get; set; } = string.Empty;
    }
}
