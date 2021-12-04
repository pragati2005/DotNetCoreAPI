using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginRegisterASPNetCore.Models
{
    public class Applicationuser : IdentityUser
    {
        public String FirstName { get; set; }
        public String SecondName { get; set; }

        public int age { get; set; }
        public String Address { get; set; }
        public int validationstatus { get; set; }

        
    }
}
