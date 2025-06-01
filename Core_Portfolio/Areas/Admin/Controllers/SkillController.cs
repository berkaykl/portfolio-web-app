using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
            ViewData["WebTitle"] = "Yetenekler - Admin";
            var values = skillManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSkill()
        {
            ViewData["WebTitle"] = "Yetenek Ekle - Admin";
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            skillManager.TAdd(skill);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteSkill(int id)
        {
            var deletedValue = skillManager.TGetById(id);

            if (deletedValue != null)
            {
                skillManager.TDelete(deletedValue);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            ViewData["WebTitle"] = "Yetenek Düzenle - Admin";
            var updatedValue = skillManager.TGetById(id);
            return View(updatedValue);
        }

        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
            skillManager.TUpdate(skill);
            return RedirectToAction("Index");
        }

    }
}
