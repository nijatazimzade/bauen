using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bauen.DAL;
using Bauen.Models;

namespace Bauen.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly AppDbContext dbContext;

        public UserController(UserManager<AppUser> _userManager, AppDbContext db)
        {
            userManager = _userManager;
            dbContext = db;
        }
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Index()
        {
            List<AppUser> users = await userManager.Users.ToListAsync();
            List<UserDTO> dto = new List<UserDTO>();
            foreach (AppUser item in users)
            {
                UserDTO user = new UserDTO
                {
                    Id = item.Id,
                    FullName = item.FullName,
                    Email = item.Email,
                    UserName = item.UserName,
                    ProfilePhoto = item.ProfilePhoto,
                    IsActive = item.IsActive,
                    Role = (await userManager.GetRolesAsync(item))[0]
                };
                dto.Add(user);
            }

            return View(dto);
        }
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> ChangeStatus(string id)
        {
            if (string.IsNullOrEmpty(id)) return RedirectToAction("Index", "User");
            AppUser user = await userManager.FindByIdAsync(id);
            UserDTO dto = new UserDTO
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                UserName = user.UserName,
                ProfilePhoto = user.ProfilePhoto,
                IsActive = user.IsActive,
                Role = (await userManager.GetRolesAsync(user))[0]
            };

            return View(dto);
        }
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> ChangeStatusConfirmed(string id)
        {
            if (string.IsNullOrEmpty(id)) return RedirectToAction("Index", "User");
            AppUser user = await userManager.FindByIdAsync(id);

            if (user.IsActive)
            {
                user.IsActive = false;
            }
            else
            {
                user.IsActive = true;
            }
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "User");
        }
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> ChangeRole(string id)
        {
            if (string.IsNullOrEmpty(id)) return RedirectToAction("Index", "User");
            AppUser user = await userManager.FindByIdAsync(id);
            UserDTO dto = new UserDTO
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                UserName = user.UserName,
                ProfilePhoto = user.ProfilePhoto,
                IsActive = user.IsActive,
                Role = (await userManager.GetRolesAsync(user))[0],
                Roles = new List<string>() { "Member", "Admin", "SuperAdmin" }
            };

            return View(dto);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeRoleConfirmed(string id, string role)
        {
            if (string.IsNullOrEmpty(id)) return RedirectToAction("Index", "User");
            if (string.IsNullOrEmpty(role)) return RedirectToAction("Index", "User");
            AppUser user = await userManager.FindByIdAsync(id);
            string currentRole = (await userManager.GetRolesAsync(user))[0];
            await userManager.RemoveFromRoleAsync(user, currentRole);
            await userManager.AddToRoleAsync(user, role);

            return RedirectToAction("Index", "User");
        }
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> ChangePassword(string id)
        {
            if (string.IsNullOrEmpty(id)) return RedirectToAction("Index", "User");
            AppUser user = await userManager.FindByIdAsync(id);
            UserDTO dto = new UserDTO
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                UserName = user.UserName,
                ProfilePhoto = user.ProfilePhoto,
                IsActive = user.IsActive,
                Role = (await userManager.GetRolesAsync(user))[0],
                Roles = new List<string>() { "Member", "Admin", "SuperAdmin" }
            };

            return View(dto);
        }

        [Authorize(Roles = "Admin,SuperAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePasswordConfirmed(string id, string password, string repeatPassword)
        {
            if (string.IsNullOrEmpty(id)) return RedirectToAction("Index", "User");
            if (string.IsNullOrEmpty(password)) return RedirectToAction("Index", "User");
            if (string.IsNullOrEmpty(repeatPassword)) return RedirectToAction("Index", "User");
            if (password != repeatPassword) return RedirectToAction("Index", "User");

            AppUser user = await userManager.FindByIdAsync(id);
            string token = await userManager.GeneratePasswordResetTokenAsync(user);
            await userManager.ResetPasswordAsync(user, token, password);

            return RedirectToAction("Index", "User");
        }


    }
}
