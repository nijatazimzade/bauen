using Bauen.DAL;
using Bauen.Models;
using Bauen.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bauen.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class BannersController : Controller
    {
        private readonly AppDbContext dbContext;
        private readonly IWebHostEnvironment env;
        public BannersController(AppDbContext db, IWebHostEnvironment _env)
        {
            dbContext = db;
            env = _env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await dbContext.Banners.ToListAsync());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Banner banner)
        {
            if (!ModelState.IsValid) return View();
            Banner duplicate = await dbContext.Banners.FirstOrDefaultAsync(x => x.Img == banner.Img);
            if (duplicate != null)
            {
                ModelState.AddModelError("Img", "Image unique olmalidir.");
                return View();
            }

            if (!banner.Image.IsImage())
            {
                ModelState.AddModelError("Image", "Fayl sekil olmalidir.");
                return View();
            }

            if (!banner.Image.IsValidSize(500))
            {
                ModelState.AddModelError("Image", "Fayl maksimum 500kb ola biler.");
                return View();
            }

            banner.Img = await banner.Image.Upload(env.WebRootPath, @"img\slider");

            await dbContext.Banners.AddAsync(banner);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Banners");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Banners");
            Banner banner = await dbContext.Banners.FindAsync(id);
            if (banner == null) return RedirectToAction("Index", "Banners");
            return View(banner);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Banners");
            Banner Banner = await dbContext.Banners.FindAsync(id);
            if (Banner == null) return RedirectToAction("Index", "Banners");
            return View(Banner);
        }
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Banners");
            Banner BannerToDelete = await dbContext.Banners.FindAsync(id);
            if (BannerToDelete == null) return RedirectToAction("Index", "Banners");

            string filePath = Path.Combine(env.WebRootPath, @"img\slider", BannerToDelete.Img);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            dbContext.Banners.Remove(BannerToDelete);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Banners");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Banners");
            Banner Banner = await dbContext.Banners.FindAsync(id);
            if (Banner == null) return RedirectToAction("Index", "Banners");
            return View(Banner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Banner Banner)
        {


            if (!ModelState.IsValid) return View();

            if (Banner.Image != null)
            {
                if (!Banner.Image.IsImage())
                {
                    ModelState.AddModelError("Image", "Fayl sekil olmalidir.");
                    return View(Banner);
                }

                if (!Banner.Image.IsValidSize(500))
                {
                    ModelState.AddModelError("Image", "Fayl maksimum 500kb ola biler.");
                    return View(Banner);
                }

                string filePath = Path.Combine(env.WebRootPath, @"img\slider", Banner.Img);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                Banner.Img = await Banner.Image.Upload(env.WebRootPath, @"img\slider");
            }

            dbContext.Banners.Update(Banner);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Banners");
        }
    }
}
