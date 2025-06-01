using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.ViewComponents.Contact
{
    public class SendMessage:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
