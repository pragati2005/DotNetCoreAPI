using Netcorewebapi.Models;
using System.Collections.Generic;

namespace Netcorewebapi.Repository
{
    public interface IProductRepository
    {
        int AddProduct(Product prd);
        List<Product> GetProductList();
    }
}