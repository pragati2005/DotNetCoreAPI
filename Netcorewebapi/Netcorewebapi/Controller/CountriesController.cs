using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Netcorewebapi.Models;
using Netcorewebapi.ModelBinder;
// Model Binding at controller :

namespace Netcorewebapi.Controller
{
    [Route("[controller]/[action]")]
    [ApiController]
    [BindProperties]
    public class CountriesController : ControllerBase
    {
        //public Country countparam { get; set; }
        ////[BindProperty]
        //public String Name { get; set; }
        ////[BindProperty]
        //public int population { get; set; }
        
        [HttpPost("")]
        public IActionResult AddCountry([FromQuery] Country count)
        {
            //Name = name;
            return Ok($"{count.Name} + {count.populationofcount} + {count.countryid}");
        }
        [HttpPost("")]
        [Route("{id}")]
        public IActionResult AddCountry2([FromRoute] int id , [FromBody] Country count)
        {
            //Name = name;
            return Ok($" in  AddCountry2 : {count.Name} + {count.populationofcount} + {count.countryid} and from route {id}");
        }
        [HttpGet("Search")]
        public IActionResult searchcountries([ModelBinder(typeof(CustomBinder))] string[] countries)
        {
            return Ok(countries);
        }
    }
}
