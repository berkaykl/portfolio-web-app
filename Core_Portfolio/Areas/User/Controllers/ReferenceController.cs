using BusinessLayer.Concrete;
using Core_Portfolio.Areas.User.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class ReferenceController : Controller
    {
        private readonly TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());
        private readonly UserManager<WriterUser> _userManager;

        public ReferenceController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["WebTitle"] = "Referans Ekle";
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Index", "Login", new { area = "User" });
            }

            var myTestimonials = testimonialManager.TGetListByFilter(x => x.WriterUserId == user.Id)
                                     .OrderByDescending(x => x.Date)
                                     .ToList();

            var model = new UserReferenceViewModel
            {
                Name = user.Name ?? string.Empty,
                Surname = user.Surname ?? string.Empty,
                WriterUserId = user.Id,
                ImageUrl = user.ImageUrl ?? string.Empty,
                MyTestimonials = myTestimonials,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddReference(UserReferenceViewModel model)
        {
            var testimonial = new Testimonial
            {
                Name = model.Name,
                Surname = model.Surname,
                Company = model.Company,
                Comment = model.Comment,
                WriterUserId = model.WriterUserId,
                ImageUrl = model.ImageUrl,
                Date = DateTime.Now
            };

            testimonialManager.TAdd(testimonial);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult DeleteReference(int id)
        {
            var deletedValue = testimonialManager.TGetById(id);
            if (deletedValue != null)
            {
                testimonialManager.TDelete(deletedValue);
            }
            

            return RedirectToAction("Index", "Reference", new { area = "User" });
        }

    }
}
