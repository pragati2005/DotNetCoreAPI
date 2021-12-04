using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Models
{
    
    public class Applicationuser : IdentityUser
    {

        //public int appuserid { get; set; }
        public String FirstName { get; set; }
        public String LastNaame { get; set; }
    }
}
