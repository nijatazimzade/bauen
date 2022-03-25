using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bauen.Areas.Admin.Models;
using Bauen.DAL;

namespace Bauen.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles= "Admin,SuperAdmin")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext dbContext;
        public DashboardController(AppDbContext db)
        {
            dbContext = db;
        }
        public async Task<IActionResult> Index()
        {
            DashboardViewModel dvm = new DashboardViewModel();
            dvm.BannerCount = await dbContext.Banners.CountAsync();
            dvm.ProjectCount = await dbContext.Projects.CountAsync();
            dvm.PartnerCount = await dbContext.Partners.CountAsync();

            return View(dvm);
        }
    }
}
