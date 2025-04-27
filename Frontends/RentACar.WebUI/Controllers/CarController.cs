using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebUI.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
