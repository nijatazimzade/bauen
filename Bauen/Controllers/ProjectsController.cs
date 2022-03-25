using Microsoft.AspNetCore.Authorization;
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
    public class ProjectsController : Controller
    {
        private readonly AppDbContext dbContext;
        public ProjectsController(AppDbContext db)
        {
            dbContext = db;
        }

        public IActionResult Info(int id)
        {
            return View(dbContext.Projects.Include(x => x.ProjectImages).First(x => x.Id == id));
        }

    }
}
