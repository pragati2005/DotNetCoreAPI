using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginRegisterASPNetCore.UserConstants;
using Microsoft.IdentityModel.Tokens;

namespace LoginRegisterASPNetCore.Models
{
    public class AthenticationTokenrepo
    {
        private readonly UserManager<Applicationuser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public IConfiguration _configuration;
        public AthenticationTokenrepo(UserManager<Applicationuser> usermanager, RoleManager<IdentityRole> rolemanager, IConfiguration configuration)
        {
            this.userManager = usermanager;
            this.roleManager = rolemanager;
            _configuration = configuration;
        }
        public async Task<String>  CreateAuthenticationToken(Applicationuser appuser)
        {
            try
            {
                if (appuser == null)
                {
                    throw new InvalidOperationException(UserContants.USERNOTVALID);
                }
                var token = await userManager.GenerateTwoFactorTokenAsync(appuser, "Email");
                if (token == null) { throw new SecurityTokenInvalidTypeException(UserContants.USERTOKEN); }
                await userManager.SetAuthenticationTokenAsync(appuser, "MyApp", "FirstTimeToken", token);

                return token;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
          

        }
    }
}
