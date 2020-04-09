using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetWebDemo.Models;
using AspNetWebDemo.Tietokanta;

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
            // tavoite: etsi viittä suuremmat luvut ja tulosta numerojärjestykseen
            int[] luvut = { 6, 8, 10, 4, 12, 9, 3, 5, 11, 2 };

            // SQL: SELECT Luku FROM Luvut WHERE Luku > 5 ORDER BY Luku
            var suuretLuvut = (from l in luvut       //   <-- LINQ-kysely
                               where l > 5
                               orderby l
                               select l).ToList();

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

        public IActionResult AsiakasListaus()
        {
            NorthwindContext konteksti = new NorthwindContext();

            // haetaan kaikki asiakkaat
            // List<Customers> asiakkaat = konteksti.Customers.ToList();

            // haetaan suomalaiset asiakkaat: LINQ-kyselysyntaksi
            List<Customers> asiakkaat = (from a in konteksti.Customers
                                         where a.Country == "Finland"
                                         select a).ToList();

            // sama kysely, mutta LINQ-metodisyntaksilla
            List<Customers> asiakkaat2 = konteksti.Customers.Where(
                a => a.Country == "Finland").ToList();

            return View(asiakkaat);
            // return View(asiakkaat2);
        }
    }
}
