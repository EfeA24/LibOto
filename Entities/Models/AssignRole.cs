using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class AssignRole : IdentityRole
    {
        [Key]
        public int RoleId { get; set; }
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }
}
