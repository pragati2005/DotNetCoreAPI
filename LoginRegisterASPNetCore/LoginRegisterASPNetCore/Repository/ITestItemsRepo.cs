using LoginRegisterASPNetCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoginRegisterASPNetCore.Repository
{
    public interface ITestItemsRepo
    {
        Task<List<TestItem>> GetAllItems();
    }
}