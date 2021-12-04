using Microsoft.EntityFrameworkCore;
using SampleDBConnectionsinEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDBConnectionsinEF.Data
{
    public class AppDBContext : DbContext
    {

    public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Author)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(bi => bi.BookId);
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Author)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(bi => bi.AuthorId);

        }
        public DbSet<Books> books { get; set; }
        public DbSet<Book_Author> books_authors { get; set; }

        public DbSet<Authors> author { get; set; }
        public DbSet<Publisher> Publishers { get; set; }


    }
}
