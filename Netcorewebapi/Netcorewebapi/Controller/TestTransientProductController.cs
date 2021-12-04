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
    public class TestTransientProductController : ControllerBase
    {
        public readonly IProductRepository _productrepo;
        public readonly IProductRepository _productrepo1;
        public TestTransientProductController(IProductRepository productreposiotory, IProductRepository productreposiotory1)
        {
            _productrepo = productreposiotory;
            _productrepo1 = productreposiotory1;
        }

        [HttpPost("")]
        public IActionResult AddNewProduct([FromBody] Product prod)
        {
            _productrepo.AddProduct(prod);
            var products = _productrepo1.GetProductList();
            var products2 = _productrepo.GetProductList();
            return Ok(products2);


        }
    }
}
