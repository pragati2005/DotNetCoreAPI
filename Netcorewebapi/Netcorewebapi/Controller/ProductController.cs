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
    public class ProductController : ControllerBase
    {
        public readonly IProductRepository _productrepo;
        public ProductController(IProductRepository productreposiotory)
        {
            _productrepo = productreposiotory;
        }

        [HttpPost("")]
        public IActionResult AddNewProduct([FromBody] Product prod)
        {
            _productrepo.AddProduct(prod);
            var products = _productrepo.GetProductList();
            return Ok(products);


        }
    }
}
