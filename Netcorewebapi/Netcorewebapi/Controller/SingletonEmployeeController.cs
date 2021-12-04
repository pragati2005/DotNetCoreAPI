using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netcorewebapi.Models;
using Netcorewebapi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netcorewebapi.Controller
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SingletonEmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _employeerepo;
        public SingletonEmployeeController(IEmployeeRepo emprepo)
        {
            _employeerepo = emprepo;
        }
        [HttpPost("")]
        public IActionResult AddnewEmployee([FromBody] Employee empo)
        {
            if(empo==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_employeerepo.AddEmployee(empo));
            }
        }
        [HttpGet]

        public IActionResult GetAllInfo()
        {
            return Ok(_employeerepo.GetEmployeeList());
        }
    }
}
