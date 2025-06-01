using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["WebTitle"] = "Referanslar - Admin";
            var values = testimonialManager.TGetList();
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(Testimonial testimonial)
        {
            testimonialManager.TAdd(testimonial);
            return View();
        }

        [HttpPost]
        public IActionResult DeleteTestimonial(int id)
        {
            var deletedValue = testimonialManager.TGetById(id);

            if (deletedValue != null)
            {
                testimonialManager.TDelete(deletedValue);
            }

            return RedirectToAction("Index");
        }
    }
}
