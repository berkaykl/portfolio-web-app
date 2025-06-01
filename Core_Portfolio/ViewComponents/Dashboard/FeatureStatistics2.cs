using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.ViewComponents.Dashboard
{
    public class FeatureStatistics2:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Portfolios.Count();
            ViewBag.v2 = c.Messages.Count();
            ViewBag.v3 = c.Services.Count();

            return View();
        }
    }
}
