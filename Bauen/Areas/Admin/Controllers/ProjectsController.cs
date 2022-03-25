using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bauen.DAL;
using Bauen.Models;
using Bauen.Utils;
using System.IO;

namespace Bauen.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class ProjectsController : Controller
    {
        private readonly AppDbContext dbContext;
        private readonly IWebHostEnvironment env;

        public ProjectsController(AppDbContext db, IWebHostEnvironment _env)
        {
            dbContext = db;
            env = _env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await dbContext.Projects.ToListAsync());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Project project)
        {
            if (!ModelState.IsValid) return View();

            Project duplicate = await dbContext.Projects.FirstOrDefaultAsync(x => x.Name == project.Name);
            if (duplicate != null)
            {
                ModelState.AddModelError("Name", "Name unique olmalidir.");
                return View();
            }

            if (!project.ImageFile.IsImage())
            {
                ModelState.AddModelError("ImageFile", "Fayl sekil olmalidir.");
                return View();
            }

            if (!project.ImageFile.IsValidSize(500))
            {
                ModelState.AddModelError("ImageFile", "Fayl maksimum 500kb ola biler.");
                return View();
            }

            project.Image = await project.ImageFile.Upload(env.WebRootPath, @"img\projects");

            await dbContext.Projects.AddAsync(project);
            await dbContext.SaveChangesAsync();

            if (project.ImageList != null && project.ImageList.Length > 0)
            {
                foreach (IFormFile item in project.ImageList)
                {
                    if (!item.IsImage())
                    {
                        ModelState.AddModelError("ImageList", item.FileName + "fayli sekil deyil.");
                        dbContext.Projects.Remove(dbContext.Projects.Find(project.Id));
                        await dbContext.SaveChangesAsync();
                        return View();
                    }

                    if (!item.IsValidSize(500))
                    {
                        ModelState.AddModelError("ImageList", item.FileName + "faylinin olcusu boyukdur.");
                        dbContext.Projects.Remove(dbContext.Projects.Find(project.Id));
                        await dbContext.SaveChangesAsync();
                        return View();
                    }

                    ProjectImage pi = new ProjectImage();
                    pi.Img = await item.Upload(env.WebRootPath, @"img\projects");
                    pi.ProjectId = project.Id;

                    await dbContext.ProjectImages.AddAsync(pi);
                }
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Projects");
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return RedirectToAction("index", "projects");
            dbContext.Projects.Include(x => x.ProjectImages).First(x => x.Id == id);
            Project proj = await dbContext.Projects.FindAsync(id);
            if (proj == null) return RedirectToAction("index", "projects");
            return View(proj);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Projects");
            dbContext.Projects.Include(x => x.ProjectImages).First(x => x.Id == id);
            Project proj = await dbContext.Projects.FindAsync(id);
            if (proj == null) return RedirectToAction("Index", "Projects");
            return View(proj);
        }
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Projects");
            dbContext.Projects.Include(x => x.ProjectImages).First(x => x.Id == id);


            Project projToDelete = await dbContext.Projects.FindAsync(id);
            if (projToDelete == null) return RedirectToAction("Index", "Projects");

            string filePath = Path.Combine(env.WebRootPath, @"img\projects", projToDelete.Image);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            dbContext.Projects.Remove(projToDelete);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Projects");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Projects");
            dbContext.Projects.Include(x => x.ProjectImages).First(x => x.Id == id);

            Project proj = await dbContext.Projects.FindAsync(id);
            if (proj == null) return RedirectToAction("Index", "Projects");
            return View(proj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Project proj, int? id)
        {

            dbContext.Projects.Include(x => x.ProjectImages).First(x => x.Id == id);

            //if (!ModelState.IsValid) return View();

            if (proj.Image != null)
            {
                if (!proj.ImageFile.IsImage())
                {
                    ModelState.AddModelError("Image", "Fayl sekil olmalidir.");
                    return View(proj);
                }

                if (!proj.ImageFile.IsValidSize(500))
                {
                    ModelState.AddModelError("Image", "Fayl maksimum 500kb ola biler.");
                    return View(proj);
                }

                string filePath = Path.Combine(env.WebRootPath, @"img\projects", proj.Image);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                proj.Image = await proj.ImageFile.Upload(env.WebRootPath, @"img\projects");
            }

            dbContext.Projects.Update(proj);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Project");
        }
    }
}
