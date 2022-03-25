using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bauen.Models
{
    public class Message:BaseEntity
    {
        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required, MaxLength(200)]
        public string Email { get; set; }

        [Required, MaxLength(500)]
        public string Subject { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
