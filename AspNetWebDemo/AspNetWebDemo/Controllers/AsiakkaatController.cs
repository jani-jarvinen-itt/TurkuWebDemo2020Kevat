using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetWebDemo.Tietokanta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetWebDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsiakkaatController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public bool LisääAsiakas(Customers asiakas)
        {
            NorthwindContext konteksti = new NorthwindContext();
            konteksti.Customers.Add(asiakas);
            konteksti.SaveChanges();

            return true;
        }

        [HttpGet]
        [Route("")]
        public List<Customers> HaeKaikki()
        {
            NorthwindContext konteksti = new NorthwindContext();
            List<Customers> asiakkaat = konteksti.Customers.ToList();
            return asiakkaat;
        }
    }
}