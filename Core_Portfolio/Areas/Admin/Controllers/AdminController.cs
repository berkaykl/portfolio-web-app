using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public AdminController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

    }
}
