using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.ViewComponents.AdminBars
{
    public class AdminUserInfoSideBar : ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public AdminUserInfoSideBar(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity?.Name);
            var role = await _userManager.GetRolesAsync(values);

            ViewBag.Name = values.Name + " " + values.Surname;
            ViewBag.Image = values.ImageUrl;

            var roleName = "";
            if (role.Contains("Admin"))
            {
                roleName = "Admin";
            }
            else if (role.Contains("User"))
            {
                roleName = "Üye";
            }
            ViewBag.Role = roleName;


            return View();
        }
    }
}
