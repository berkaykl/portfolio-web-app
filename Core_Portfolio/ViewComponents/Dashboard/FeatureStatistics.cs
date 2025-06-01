using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.ViewComponents.Dashboard
{
    public class FeatureStatistics:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewData["v1"] = c.Skills.Count();
            ViewData["v2"] = c.Portfolios.Count();
            ViewData["v3"] = c.Messages.Count(x => x.Status == false);
            ViewData["v4"] = c.Experiences.Count();
            return View();
        }
    }
}
