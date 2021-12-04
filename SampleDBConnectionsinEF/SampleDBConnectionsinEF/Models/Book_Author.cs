using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDBConnectionsinEF.Models
{
    public class Book_Author
    {
        public int Id { get; set; }
        public int BookId { get; set; }

        public Books book { get; set; }
        public int AuthorId { get; set; }
        public Authors Author { get; set; }
    }
}
