using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace l22.Controllers
{
    [ApiController]
    [Route("cities")]
    public class CitiesController: Controller
    {
        [HttpGet]
        public JsonResult GetCities()
        {
            var result = new JsonResult(new List<object>
            {
                new { Id = 1, Name = "Moscow",},
                new { Id = 2, Name = "St. Petersburg"},
                new { Id = 3, Name = "New-York"}
            });
            return result;
        }
    }
}
