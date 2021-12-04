using LoginRegisterASPNetCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginRegisterASPNetCore.Repository
{
    public class Verification
    {

        private readonly UserManager<Applicationuser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public IConfiguration _configuration;
        public Verification(UserManager<Applicationuser> usermanager, RoleManager<IdentityRole> rolemanager, IConfiguration configuration, SendEmail.Repository.IEmailSender emailsender)
        {
            this.userManager = usermanager;
            this.roleManager = rolemanager;
            _configuration = configuration;

        }
        //public async Task<String> VerifyCode(Applicationuser userapp,String tokenprovided)
        //{
        //    try
        //    {
        //        var refreshToken = await userManager.GetAuthenticationTokenAsync(userapp, "MyApp", "FirstTimeToken");
        //        if(refreshToken==tokenprovided)
        //        {
        //            userapp.
        //        }
        //            }
        //    catch(Exception ex)
        //    {
        //        return "Bad Token Provided , user email not verified"+ex.Message;
        //    }
        //    //var isValid = await _userManager.VerifyUserTokenAsync(user, "MyApp", "RefreshToken", refreshToken);
        //}
    }
}
