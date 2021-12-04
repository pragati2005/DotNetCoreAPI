using LoginRegisterASPNetCore.IdentityAuth;
using LoginRegisterASPNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginRegisterASPNetCore.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class VerificationController : ControllerBase
    {
        private readonly UserManager<Applicationuser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public IConfiguration _configuration;
        public VerificationController(UserManager<Applicationuser> usermanager, RoleManager<IdentityRole> rolemanager, IConfiguration configuration, SendEmail.Repository.IEmailSender emailsender)
        {
            this.userManager = usermanager;
            this.roleManager = rolemanager;
            _configuration = configuration;
           
        }
        [HttpPost]
       
        public async Task<IActionResult> Verifycode([FromBody] VerificationModel verifydetails)
        {
            try
            {
                var codeexist = userManager.FindByEmailAsync(verifydetails.Emailaddress);
                if (codeexist == null)
                {
                    throw new InvalidOperationException("Incorrect Email details");
                }
                Applicationuser appuser = await codeexist;
                if (appuser.validationstatus==0)
                {

                    //bool verification = await Verifycode(userid, verifydetails.Tokencode);
                    var authenticationtoken = await userManager.GetAuthenticationTokenAsync(appuser, "MyApp", "FirstTimeToken");
                    //var result = await userManager.VerifyUserTokenAsync(appuser, "MyApp", "authenticationToken", verifydetails.Tokencode);

                    if(authenticationtoken==verifydetails.Tokencode)
                    {
                        appuser.validationstatus = 1;

                        IdentityResult result2 = await userManager.UpdateAsync(appuser);
                    }

                    else
                    {
                        throw new Exception("The email is not verified due to invalid token");
                    }
                    //Applicationuser user = new Applicationuser()
                    //{
                    //    Email = appuser.Email,
                    //    SecurityStamp = appuser.SecurityStamp,
                    //    UserName = appuser.UserName,
                    //    PhoneNumber = appuser.PhoneNumber,
                    //    age =appuser.age,
                    //    Address =appuser.Address,
                    //    EmailConfirmed = true,
                    //    TwoFactorEnabled = appuser.TwoFactorEnabled,
                    //    validationstatus =1
                    //};
                   
                                        
                    
                    return Ok(new Response { Status = "success", Message = "!!!  Email in succesfully Verified !!!! " });
                }

                else
                {
                    throw new Exception("User is already validated");
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            



         

        }
        
    }
}
