using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarProject.DTO.CarDTOs;
using RentACarProject.DTO.CarPricingDTOs;
using RentACarProject.DTO.ServiceDTOs;

namespace RentACarProject.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public CarController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Araçlarımız";
            ViewBag.v2 = "Aracınızı Seçiniz";
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7290/api/CarPricings");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarDTOs>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
