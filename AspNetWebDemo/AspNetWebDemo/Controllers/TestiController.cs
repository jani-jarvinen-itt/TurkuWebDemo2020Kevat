using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetWebDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetWebDemo.Controllers
{
    [Route("api/[controller]")]   // attribuutti (attribute)
    [ApiController]
    public class TestiController : ControllerBase
    {
        [Route("eka")]
        public string Eka()
        {
            return "Hello, World!";
        }

        [Route("toka")]
        public string Toka()
        {
            return "Tämä on toinen metodi.";
        }

        [Route("pvm")]
        public DateTime Päivämäärä()
        {
            return DateTime.Now;
        }

        [Route("numerot")]
        public List<int> PalautaNumeroLista()
        {
            List<int> numerot = new List<int>() { 1, 2, 3, 4, 5 };
            return numerot;
        }

        [Route("asiakkaat")]
        public List<Asiakas> HaeAsiakasLista()
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

            return asiakkaat;
        }
    }
}