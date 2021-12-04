using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netcorewebapi.Controller
{
    [ApiController]
    [Route("test/[action]")]
    public class TestController : ControllerBase
    {

        [HttpGet]
    public String Get()
        {
            return "Hello by test controller from get ";
        }
        [HttpGet]

        public String Get1()
        {
            return "Hello by test controller from Get1";
        }

    }
}
