using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
