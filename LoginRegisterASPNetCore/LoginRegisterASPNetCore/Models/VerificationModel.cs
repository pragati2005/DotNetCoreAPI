using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginRegisterASPNetCore.Models
{
    public class VerificationModel
    {
        public String Emailaddress { get; set; }
        public String Tokencode { get; set; }
    }
}
