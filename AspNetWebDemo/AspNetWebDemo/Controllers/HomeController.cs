using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetWebDemo.Models;

namespace AspNetWebDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string OmaJuttu()
        {
            return "Moro, täällä ollaan!";
        }

        public string Kellonaika()
        {
            return DateTime.Now.ToString();
        }

        public IActionResult UusiSivu()
        {
            List<Asiakas> asiakkaat = new List<Asiakas>()
            {
                new Asiakas()
                {
                    AsiakasId = 100,
                    AsiakkaanNimi = "Yritys Oy",
                    Sähköpostiosoite = "info@yritys.fi"
                },
                new Asiakas()
                {
                    AsiakasId = 101,
                    AsiakkaanNimi = "Asiakas Oy",
                    Sähköpostiosoite = "info@asiakas.fi"
                },
                new Asiakas()
                {
                    AsiakasId = 102,
                    AsiakkaanNimi = "Testaus Oy",
                    Sähköpostiosoite = "info@testaus.com"
                }
            };

            ViewBag.NapinVäri = "danger";
            ViewBag.NäytäLista = false;

            return View(asiakkaat);
        }
    }
}
