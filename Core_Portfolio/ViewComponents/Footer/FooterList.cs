using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.ViewComponents.Footer
{
    public class FooterList:ViewComponent
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());

        public IViewComponentResult Invoke()
        {
            var values = featureManager.TGetById(1);
            return View(values);
        }
    }
}
