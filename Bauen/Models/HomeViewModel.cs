using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bauen.Models
{
    public class HomeViewModel
    {
        public List<Banner> Banners { get; set; }
        public HomeAboutSection HomeAboutSection { get; set; }
        public List<Partner> Partners { get; set; }
        public List<Project> Projects { get; set; }
        public List<AppUser> Users { get; set; }
    }
}
