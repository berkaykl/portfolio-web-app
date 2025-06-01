using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class CommunicationController : Controller
    {
        public IActionResult Index()
        {
            ViewData["WebTitle"] = "İletişim";
            return View();
        }
    }
}
