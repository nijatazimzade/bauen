using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bauen.Models
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string ProfilePhoto { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public List<string> Roles { get; set; }
    }
}
