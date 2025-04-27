using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebUI.Controllers
{
    public class AdminBrandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
