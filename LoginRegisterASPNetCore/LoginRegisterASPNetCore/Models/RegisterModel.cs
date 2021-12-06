using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginRegisterASPNetCore.Models
{
    public class RegisterModel
    {
        
        [Required(ErrorMessage ="Username is required")]
        public String UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is required")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Password is required")]   // "[0-9]*$"
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Mobile number : 10 digits required")]
        public String MobileNumber { get; set; }
        public String Address { get; set; }
        [Required]
        [Range(18, 100,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Age { get; set; }
        public Boolean status { get; set; }
        
    }
}
