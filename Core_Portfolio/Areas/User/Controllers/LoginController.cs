using Core_Portfolio.Areas.User.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Areas.User.Controllers
{
    [AllowAnonymous]
    [Area("User")]
    public class LoginController : Controller
    {
        private readonly SignInManager<WriterUser> _signInManager;
        private readonly UserManager<WriterUser> _userManager;

        public LoginController(SignInManager<WriterUser> signInManager, UserManager<WriterUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.UserName, p.Password, true, true);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(p.UserName);
                

                    //Rol kontrolü ile yönlendirme
                    if (await _userManager.IsInRoleAsync(user, "Admin"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                    }
                    else if (await _userManager.IsInRoleAsync(user, "User"))
                    {
                        return RedirectToAction("Index", "Profile", new { area = "User" });
                    }
                    else
                    {
                        // Eğer rolü yoksa log out yapar ve giriş sayfasına yönlendirilir
                        await _signInManager.SignOutAsync();
                        ModelState.AddModelError("", "Kullanıcıya ait rol bulunamadı.");
                        return View();
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre!");
                }
            }

            return View();
        } 

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login", new {area = "User"});
        }
    }
}
