﻿using BusinessLayer.Concrete;
using Core_Portfolio.Areas.User.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["WebTitle"] = "Profilim";

            var values = await _userManager.FindByNameAsync(User.Identity?.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.Surname = values.Surname;
            model.UserName = values.UserName;
            model.PictureUrl = values.ImageUrl;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            //resim yükleme
            var user = await _userManager.FindByNameAsync(User.Identity?.Name);
            if (p.Picture != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Picture.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = Path.Combine(resource, "wwwroot/userimage", imagename);

                using var stream = new FileStream(savelocation, FileMode.Create);
                await p.Picture.CopyToAsync(stream);

                user.ImageUrl = imagename;
            }
            user.Name = p.Name;
            user.Surname = p.Surname;
            user.UserName = p.UserName;

            if (!string.IsNullOrWhiteSpace(p.Password))
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            }

            var result = await _userManager.UpdateAsync(user);

            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Profile", new { area = "User"});
            }

            return View();
        }
    }
}
