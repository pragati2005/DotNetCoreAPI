using Netcorewebapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netcorewebapi.Repository
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> productlist = new List<Product>();
        public int AddProduct(Product prd)
        {
            prd.prodid = productlist.Count + 1;
            productlist.Add(prd);
            return prd.prodid;

        }

        public List<Product> GetProductList()
        {
            return productlist;
        }
    }
}
