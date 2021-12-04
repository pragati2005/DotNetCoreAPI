using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Netcorewebapi.Models;

namespace Netcorewebapi.Controller
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {

        List<Animals> animal;
        public AnimalController()
        { animal=new List<Animals>();
            animal.Add(new Animals { animalname = "Dog", Id = 1 });
            animal.Add(new Animals { animalname = "Cat", Id = 2 });
            animal.Add(new Animals { animalname = "Donkey", Id = 3 });
        }

        // Complete URL : https://localhost:44390/Animal/GetAnimalsok
        public IActionResult GetAnimalsok()
        {
            var animal1 = new Animals { animalname = "Duck", Id = 4 };
            
            return Ok(animal.Append<Animals>(animal1));
        }
        [Route("test")]
        public IActionResult GetAnimalaccepted()
        {
            var animal = new List<Animals>()
            {
                new Animals{Id=3,animalname="Whale"},
                new Animals{Id=4,animalname="Dolphin"}
            };
            return Accepted(animal);
        }
        public IActionResult GetAnimalacceptedvalue()
        {
          
            
            return Accepted("~/api/animal");
        }
        [Route("BadRequestExample/{name}/{id:int}")]

        // Complete URL : https://localhost:44390/Animal/GetAnimalBadRequestDemo/BadRequestExample/Nitesh/2
        public IActionResult GetAnimalBadRequestDemo(String name,int Id)
        {
            if(!name.Contains("ABC"))
            {
                return BadRequest("Please enter string having substring ABC");
            }
            else
            {
                var animal = new Animals { animalname = name, Id = Id };
                return Ok(animal);
            }
        }
        [Route("{id:int}")]
        public IActionResult GetAnimalsById(int id)
        {
            if(id==0)
            {
                return BadRequest("The Id could not be one");
            }
            else
            {
                return Ok(animal.FirstOrDefault(x=>x.Id==id));
            }
            if(animal==null)
            {
                return NotFound();
            }
            return Ok(animal);
        }
        [HttpPost]
        public IActionResult GetAnimals(Animals anm)
        {
            animal.Add(anm);
            return Created("~/api/animal", new { Id = anm.Id });
        }
        [Route("ShowAnimals")]
        // URL used : https://localhost:44390/Animal/RedirectMethod/ShowAnimals
        public IActionResult RedirectMethod()
        {
            return LocalRedirect("~/api/animals");
        }


    }
}
