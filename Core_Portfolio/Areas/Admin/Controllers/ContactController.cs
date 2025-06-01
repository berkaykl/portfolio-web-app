using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["WebTitle"] = "İletişim - Admin";
            var values = contactManager.TGetById(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contactManager.TUpdate(contact);
            return Redirect("/User/Default/Index#contact");
        }
    }
}
