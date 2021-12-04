using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDBConnectionsinEF.Models
{
    public class Authors
    {
        public int Id { get; set; }
        public String FullName { get; set; }
        public List<Book_Author> Book_Authors { get; set; }
    }
}
