using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bauen.Models
{
    public class Banner : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string BtnText { get; set; }
        [Required]
        public string BtnLink { get; set; }
        public string Img { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
