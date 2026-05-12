using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETbugTracker.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int RoleId { get; set; }  // 1=Admin, 2=Developer, 3=Tester
        public virtual Role? Role { get; set; }
    }
}