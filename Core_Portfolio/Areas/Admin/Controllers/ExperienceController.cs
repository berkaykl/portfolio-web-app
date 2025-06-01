using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            ViewData["WebTitle"] = "Deneyimler - Admin";
            var values = experienceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddExperience()
        {
            ViewData["WebTitle"] = "Deneyim Ekle - Admin";
            return View();
        }

        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.TAdd(experience);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteExperience(int id)
        {
            var deletedValue = experienceManager.TGetById(id);
            if (deletedValue != null)
            {
                experienceManager.TDelete(deletedValue);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditExperience(int id)
        {
            ViewData["WebTitle"] = "Deneyim Güncelle - Admin";
            var updatedValue = experienceManager.TGetById(id);
            return View(updatedValue);
        }

        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            experienceManager.TUpdate(experience);
            return RedirectToAction("Index");
        }
    }
}
