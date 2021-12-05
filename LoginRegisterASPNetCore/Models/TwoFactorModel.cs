using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginRegisterASPNetCore.Models
{
    public class TwoFactorModel
    {
        public String TwoFactorCode { get; set; }
        public String Message { get; set; }
    }

}
