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
    public class PartnersController : Controller
    {
        private readonly AppDbContext dbContext;
        private readonly IWebHostEnvironment env;
        public PartnersController(AppDbContext db, IWebHostEnvironment _env)
        {
            dbContext = db;
            env = _env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await dbContext.Partners.ToListAsync());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Partner partner)
        {
            if (!ModelState.IsValid) return View();

            Partner duplicate = await dbContext.Partners.FirstOrDefaultAsync(x => x.Img == partner.Img);
            if (duplicate != null)
            {
                ModelState.AddModelError("Image", "Image unique olmalidir.");
                return View();
            }

            if (!partner.Image.IsImage())
            {
                ModelState.AddModelError("Image", "Fayl sekil olmalidir.");
                return View();
            }

            if (!partner.Image.IsValidSize(500))
            {
                ModelState.AddModelError("Image", "Fayl maksimum 500kb ola biler.");
                return View();
            }

            partner.Img = await partner.Image.Upload(env.WebRootPath, @"img\clients");

            await dbContext.Partners.AddAsync(partner);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Partners");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Partners");
            Partner partner = await dbContext.Partners.FindAsync(id);
            if (partner == null) return RedirectToAction("Index", "Partners");
            return View(partner);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Partners");
            Partner partner = await dbContext.Partners.FindAsync(id);
            if (partner == null) return RedirectToAction("Index", "Partners");
            return View(partner);
        }
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Partners");
            Partner partnerToDelete = await dbContext.Partners.FindAsync(id);
            if (partnerToDelete == null) return RedirectToAction("Index", "Partners");

            string filePath = Path.Combine(env.WebRootPath, @"img\clients", partnerToDelete.Img);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            dbContext.Partners.Remove(partnerToDelete);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Partners");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Partners");
            Partner partner = await dbContext.Partners.FindAsync(id);
            if (partner == null) return RedirectToAction("Index", "Partners");
            return View(partner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Partner partner)
        {


            if (!ModelState.IsValid) return View();

            if (partner.Image != null)
            {
                if (!partner.Image.IsImage())
                {
                    ModelState.AddModelError("Image", "Fayl sekil olmalidir.");
                    return View(partner);
                }

                if (!partner.Image.IsValidSize(500))
                {
                    ModelState.AddModelError("Image", "Fayl maksimum 500kb ola biler.");
                    return View(partner);
                }

                string filePath = Path.Combine(env.WebRootPath, @"img\clients", partner.Img);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                partner.Img = await partner.Image.Upload(env.WebRootPath, @"img\clients");
            }

            dbContext.Partners.Update(partner);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Partners");
        }
    }
}
