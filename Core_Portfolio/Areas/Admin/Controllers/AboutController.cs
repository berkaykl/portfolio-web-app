using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["WebTitle"] = "Hakkında - Admin";
            var values = aboutManager.TGetById(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(About about)
        {
            aboutManager.TUpdate(about);
            return Redirect("/User/Default/Index#contact");
        }
    }
}
