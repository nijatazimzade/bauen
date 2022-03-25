using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;
using Bauen.DAL;
using Bauen.Models;
using Bauen.Utils;

namespace Bauen.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class HomeAboutSectionController : Controller
    {
        private readonly AppDbContext dbContext;
        private readonly IWebHostEnvironment env;
        public HomeAboutSectionController(AppDbContext db, IWebHostEnvironment _env)
        {
            dbContext = db;
            env = _env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await dbContext.HomeAboutSections.FirstOrDefaultAsync());
        }

 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return RedirectToAction("Index", "HomeAboutSection");
            HomeAboutSection has = await dbContext.HomeAboutSections.FindAsync(id);
            if (has == null) return RedirectToAction("Index", "HomeAboutSection");
            return View(has);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return RedirectToAction("Index", "HomeAboutSection");
            HomeAboutSection has = await dbContext.HomeAboutSections.FindAsync(id);
            if (has == null) return RedirectToAction("Index", "HomeAboutSection");
            return View(has);
        }
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null) return RedirectToAction("Index", "HomeAboutSection");
            HomeAboutSection hasToDelete = await dbContext.HomeAboutSections.FindAsync(id);
            if (hasToDelete == null) return RedirectToAction("Index", "HomeAboutSection");

            string filePath = Path.Combine(env.WebRootPath, @"img\about", hasToDelete.Img);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            dbContext.HomeAboutSections.Remove(hasToDelete);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "HomeAboutSection");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index", "HomeAboutSection");
            HomeAboutSection has = await dbContext.HomeAboutSections.FindAsync(id);
            if (has == null) return RedirectToAction("Index", "HomeAboutSection");
            return View(has);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HomeAboutSection has)
        {


            if (!ModelState.IsValid) return View();

            if (has.Image != null)
            {
                if (!has.Image.IsImage())
                {
                    ModelState.AddModelError("Image", "Fayl sekil olmalidir.");
                    return View(has);
                }

                if (!has.Image.IsValidSize(500))
                {
                    ModelState.AddModelError("Image", "Fayl maksimum 500kb ola biler.");
                    return View(has);
                }

                string filePath = Path.Combine(env.WebRootPath, @"img\about", has.Img);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                has.Img = await has.Image.Upload(env.WebRootPath, @"img\about");
            }

            dbContext.HomeAboutSections.Update(has);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "HomeAboutSection");
        }
    }
}
