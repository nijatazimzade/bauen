using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bauen.Models
{
    public class HomeAboutSection : BaseEntity
    {
        public string LeftHtml { get; set; }
        public string Img { get; set; }
        public string ImgName { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }

    }
}
