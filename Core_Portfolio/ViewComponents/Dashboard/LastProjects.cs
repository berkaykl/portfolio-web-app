using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.ViewComponents.Dashboard
{
    public class LastProjects:ViewComponent
    {
        private readonly PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IViewComponentResult Invoke()
        {
            var values = portfolioManager.TGetLast5Projects();
            return View(values);
        }
    }
}
