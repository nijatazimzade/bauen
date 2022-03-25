using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bauen.Models
{
    public class ProjectImage:BaseEntity
    {
        public string Img { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }

    }
}
