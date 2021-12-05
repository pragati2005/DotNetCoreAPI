using LoginRegisterASPNetCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginRegisterASPNetCore.Data
{
    public class DataDBContext:IdentityDbContext<Applicationuser>
    {
        public DataDBContext(DbContextOptions<DataDBContext> options):base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<TestItem> TestItems { get; set; }
    }
}
