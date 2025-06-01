using Core_Portfolio.Areas.User.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Areas.User.Controllers
{
    [AllowAnonymous]
    [Area("User")]
    public class RegisterController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserRegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {
            if (ModelState.IsValid)
            {
                WriterUser writerUser = new WriterUser()
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    Email = p.Mail,
                    UserName = p.UserName,
                    ImageUrl = p.ImageUrl,
                };

                if (p.Password == p.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(writerUser, p.Password);
                    //var user = await _userManager.FindByNameAsync(p.UserName);

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(writerUser, "User");

                        //admin ataması için
                        //if (!await _userManager.IsInRoleAsync(user, "Admin"))
                        //{
                        //    if (p.UserName == "berkaykol28")
                        //    {
                        //        var addRoleResult = await _userManager.AddToRoleAsync(user, "Admin");
                        //        if (!addRoleResult.Succeeded)
                        //        {
                        //            // Hata loglama ya da işlem için
                        //        }
                        //    }
                        //}

                        return RedirectToAction("Index", "Login", new { area = "User" });
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
            }

            return View(p);
        }

    }
}
// Berkay.5208