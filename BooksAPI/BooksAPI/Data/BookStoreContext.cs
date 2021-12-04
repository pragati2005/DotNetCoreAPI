using BooksAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Data
{
    public class BookStoreContext : IdentityDbContext<Applicationuser>
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options):base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<IdentityUserLogin<String>>().HasNoKey();
            base.OnModelCreating(modelBuilder);



        }



        public DbSet<Book>  Book { get; set; }
        public DbSet<Author> Author{ get; set; }

        
        public DbSet<Applicationuser> ApplicationUser { get; set; }

    }
}
