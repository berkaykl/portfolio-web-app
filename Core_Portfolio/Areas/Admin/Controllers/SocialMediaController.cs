using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SocialMediaController : Controller
    {
        private readonly SocialMediaManager socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());


        public IActionResult Index()
        {
            ViewData["WebTitle"] = "Sosyal Medya - Admin";
            var values = socialMediaManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            ViewData["WebTitle"] = "Sosyal Medya Ekle - Admin";
            return View();
        }

        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia socialMedia)
        {
            socialMediaManager.TAdd(socialMedia);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteSocialMedia(int id)
        {
            var deletedValue = socialMediaManager.TGetById(id);

            if (deletedValue != null)
            {
                socialMediaManager.TDelete(deletedValue);
            }

            return RedirectToAction("Index", "SocialMedia", new {area = "Admin"});
        }


        [HttpGet]
        public IActionResult EditSocialMedia(int id)
        {
            ViewData["WebTitle"] = "Sosyal Medya Güncelle - Admin";
            var updatedValue = socialMediaManager.TGetById(id);
            return View(updatedValue);
        }

        [HttpPost]
        public IActionResult EditSocialMedia(SocialMedia socialMedia)
        {
            socialMediaManager.TUpdate(socialMedia);
            return RedirectToAction("Index", "SocialMedia", new { area = "Admin" });
        }


    }
}
