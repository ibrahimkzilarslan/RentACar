﻿using Microsoft.AspNetCore.Mvc;

namespace RentACarProject.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.v1 = "Hakkımızda";
            ViewBag.v2 = "Hakkımızda";
            return View();
        }
    }
}
