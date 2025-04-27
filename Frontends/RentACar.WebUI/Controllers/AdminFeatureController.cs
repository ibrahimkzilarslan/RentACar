using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebUI.Controllers
{
    public class AdminFeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
