using LoginRegisterASPNetCore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginRegisterASPNetCore.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public readonly ITestItemsRepo _itemrepository;
        public TestController(ITestItemsRepo itemrepository)
        {
            _itemrepository = itemrepository;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllItems()
        {
            var item = await _itemrepository.GetAllItems();
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
