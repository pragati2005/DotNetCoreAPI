using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDBConnectionsinEF.Models
{
    public class Books
    {
        public int id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public bool IsRead { get; set; }

        public DateTime? DateRead { get; set; }

        public int? Rate { get; set; }

        public String genere { get; set; }

        public String Author { get; set; }

        public String? Coverurl { get; set; }

        public DateTime DateAdded { get; set; }

        public int publisherid { get; set; }
        public Publisher Publisher { get; set; }
        public List<Book_Author> Book_Authors { get; set; }

    }
}
