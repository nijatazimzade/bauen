using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bauen.Models
{
    public class Project : BaseEntity
    {

        [Required(AllowEmptyStrings = false), MaxLength(100)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(100)]
        public string Title { get; set; }

        public string Image { get; set; }

        [Required(AllowEmptyStrings = false), MaxLength(100)]
        public string Company { get; set; }

        [Required(AllowEmptyStrings = false), MaxLength(100)]
        public string Location { get; set; }

        [Required]
        public int Year { get; set; }
        public List<ProjectImage> ProjectImages { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string DetailedText { get; set; }
        [NotMapped]
        public IFormFile[] ImageList { get; set; }


    }
}
