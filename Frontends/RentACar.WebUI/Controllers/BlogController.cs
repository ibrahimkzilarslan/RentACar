using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebUI.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
