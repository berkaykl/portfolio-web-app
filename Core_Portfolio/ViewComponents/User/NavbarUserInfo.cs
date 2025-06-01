using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.ViewComponents.User
{
    public class NavbarUserInfo:ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public NavbarUserInfo(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity?.Name);
            ViewBag.Name = values.Name + " " + values.Surname;
            ViewBag.Image = values.ImageUrl;

            return View();
        }
    }
}
