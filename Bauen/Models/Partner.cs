using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bauen.Models
{
    public class Partner : BaseEntity
    {
        public string Img { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
