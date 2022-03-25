using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bauen.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string ProfilePhoto { get; set; }
        public bool IsActive { get; set; }
    }
}
