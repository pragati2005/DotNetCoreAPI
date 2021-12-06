using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginRegisterASPNetCore.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="Username or mobile number is required")]
        public String UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public String Password { get; set; }
    }
}
