using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
        public IActionResult Index()
        {
            ViewData["WebTitle"] = "Hizmetler - Admin";
            var values = serviceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            ViewData["WebTitle"] = "Hizmet Ekle - Admin";
            return View();
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
            serviceManager.TAdd(service);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteService(int id)
        {
            var deletedValue = serviceManager.TGetById(id);
            if (deletedValue != null)
            {
                serviceManager.TDelete(deletedValue);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {
            ViewData["WebTitle"] = "Hizmet Güncelle - Admin";
            var updatedValue = serviceManager.TGetById(id);
            return View(updatedValue);
        }

        [HttpPost]
        public IActionResult EditService(Service service)
        {
            serviceManager.TUpdate(service);
            return RedirectToAction("Index");
        }

    }
}
