using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginRegisterASPNetCore.Data;
using LoginRegisterASPNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginRegisterASPNetCore.Repository
{
    public class TestItemsRepo : ITestItemsRepo
    {
        private readonly DataDBContext _dbContext;
        public TestItemsRepo(DataDBContext context)
        {
            _dbContext = context;
        }
        public async Task<List<TestItem>> GetAllItems()
        {
            var records = await _dbContext.TestItems.Select(x => new TestItem()
            {
                //BookId = x.BookId,
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
            return records;
        }
       
    }
}
