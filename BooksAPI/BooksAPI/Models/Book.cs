using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Models
{
    public class Book
    {
        //public int Id { get; set; }
        //public int BookId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public int Authorid { get; set; }
    }
}
