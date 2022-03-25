using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bauen.DAL;
using Bauen.Models;

namespace Bauen.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext dbContext;
        private readonly UserManager<AppUser> userManager;

        public HomeController(AppDbContext db, UserManager<AppUser> _userManager)
        {
            dbContext = db;
            userManager = _userManager;
        }

        public IActionResult Index()
        {
            HomeViewModel hvm = new HomeViewModel {
                Banners = dbContext.Banners.ToList(),
                Projects = dbContext.Projects.ToList(),
                Partners = dbContext.Partners.ToList(),
                HomeAboutSection = dbContext.HomeAboutSections.FirstOrDefault(),
                Users = userManager.Users.Where(x => x.IsActive == true).ToList()
            };

            return View(hvm);
        }
    }
}
