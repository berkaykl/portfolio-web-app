using Core_Portfolio.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            ErrorViewModel model = new ErrorViewModel();

            switch (statusCode)
            {
                case 404:
                    model.StatusCode = statusCode;
                    model.ErrorMessage = "Sayfa bulunamadı.";
                    break;
                case 403:
                    model.StatusCode = statusCode;
                    model.ErrorMessage = "Bu sayfaya erişim izniniz yok.";
                    break;
                default:
                    model.StatusCode = statusCode;
                    model.ErrorMessage = "Bir hata oluştu.";
                    break;
            }

            return View("ErrorPage", model);

        }
    }
}
