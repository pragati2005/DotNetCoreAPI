using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netcorewebapi.Controller
{
    [Route("api")]
    [ApiController]
    public class ContraintsController : ControllerBase
    {
        [Route("{id:int:min(10):max(100)}")]
        public String GetById(int id)
        {
            return "The return is from integer method GetById : " + id;
        }
        [Route("{id:minlength(3):maxlength(100)}")]
        public String GetByIdString(String id)
        {
            return "The return is from string method GetByIdString : " + id;
        }
        [Route("{name:regex(a(b|c))}")]
        public String GetByIdStringregex(String name)
        {
            return "The return is from regex method GetByIdString using regex : " + name;
        }
    }
}

