using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}