using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Netcorewebapi.Models;

namespace Netcorewebapi.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        Employee emp;
        List<Employee> emplist = new List<Employee>();
        [HttpGet]
        public String GetEmployeeName()
        {
            return "Returning string name of employee";
        }
        public Employee GetSingleEmployee()
        { emp = new Employee { id = 1, Name = "Anisha" };
            return emp;
        }
        public List<Employee> GetEmployeeList()
        {
            emplist.Add(new Employee { id = 2, Name = "Manish" });
            emplist.Add(new Employee { id = 3, Name = "Manisha" });

            return emplist;
        }
        public IEnumerable<Employee> GetEmployeeListenumerable()
        {
            emplist.Add(new Employee { id = 4, Name = "Manish enum" });
            emplist.Add(new Employee { id = 5, Name = "Manisha enum" });

            return emplist;
        }

        [Route("{id:int}")]
        public IActionResult GetEmployees(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(new List<Employee>()
                {
                    new Employee{id=1,Name="ABC"},
                    new Employee{id=2,Name="DEF"}
                });


            }   
        }
            [Route("{id:int}")]
            public ActionResult<List<Employee>> GetEmployeeusingActionResult(int id)
            {
            if(id==0)
            {
                return NotFound();
            }
            else
            {
                return new List<Employee>()
                {
                    new Employee{id=1,Name="ABD"},
                    new Employee{id=2,Name="BDE"}
                };
            }

            }
   }
    
}
