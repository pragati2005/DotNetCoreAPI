using LoginRegisterASPNetCore.IdentityAuth;
using LoginRegisterASPNetCore.UserConstants;
using LoginRegisterASPNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LoginRegisterASPNetCore.Data;



namespace LoginRegisterASPNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<Applicationuser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public IConfiguration _configuration;
        private readonly SendEmail.Repository.IEmailSender _emailsender;
        //private readonly IMailService mailService;
        public AuthenticateController(UserManager<Applicationuser> usermanager, RoleManager<IdentityRole> rolemanager, IConfiguration configuration,SendEmail.Repository.IEmailSender emailsender)
        {
            this.userManager = usermanager;
            this.roleManager = rolemanager;
            _configuration = configuration;
            _emailsender = emailsender;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            try {
                var userExists = await userManager.FindByNameAsync(model.UserName);

                var emailExists = await userManager.FindByEmailAsync(model.Email);

                if (userExists != null)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
                if (emailExists != null)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Email already exists!" });
                bool IsPhoneAlreadyRegistered = userManager.Users.Any(item => item.PhoneNumber == model.MobileNumber);
                if (IsPhoneAlreadyRegistered)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Mobile number already exists!" });
                }

                Applicationuser user = new Applicationuser()
                {
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.UserName,
                    PhoneNumber = model.MobileNumber,
                    age = model.Age,
                    Address = model.Address,
                    EmailConfirmed = true,
                    TwoFactorEnabled = model.status,
                    validationstatus = 0
                };



                var result = await userManager.CreateAsync(user, model.Password);
                var token = new AthenticationTokenrepo(userManager, roleManager, _configuration).CreateAuthenticationToken(user);

                if (token == null) { throw new SecurityTokenInvalidTypeException(UserContants.USERTOKEN); }
                String tokenstring = token.Result;

                //await userManager.SetAuthenticationTokenAsync(user, "MyApp", "FirstTimeToken", tokenstring);

                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, result.ToString());
                }

                //var message = new SendEmail.Models.Message(new string[] { "pragati11102268@gmail.com" }, "Test email async", "This is the content from our async email.");
                //await _emailsender.SendEmailAsync(message);
                var messagetosend = " Hi ! " + (user.UserName).ToString() + "\n" + "Please enter the following code to verify email " + tokenstring;

                var message = new SendEmail.Models.Message(new string[] {(user.Email).ToString ()}, "Email Verification code", messagetosend);
                await _emailsender.SendEmailAsync(message);


                return Ok(new Response { Status = "Success", Message = "User created successfully!" + " Token is sent to "+user.Email.ToString()+ "Please enter the code to verify the email"});
            }
            catch (InvalidOperationException ex) { return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); }
           

            
        }




        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel    model)
        {
            Applicationuser user;

            if (Double.TryParse(model.UserName, out Double num))
            {
                //user = userManager.Users.Where(s => s.PhoneNumber == model.UserName)
                //    .FirstOrDefault<Applicationuser>();
               user = userManager.Users.FirstOrDefault(u => u.PhoneNumber == model.UserName);

            }
            else
            {
                user = await userManager.FindByNameAsync(model.UserName);
            }
            //userManager.Users.Any(item => item.PhoneNumber == model.UserName);
          
            //var success = int.TryParse(model.UserName, out int result);
            
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userroles = await userManager.GetRolesAsync(user);
                var Authclaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName),
               //new Claim(JwtRegisteredClaimNames.Sub,"bob"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            //new Claim("MemberId","100")

            };
                //foreach (var userRole in userroles)
                //{
                //    Authclaims.Add(new Claim(ClaimTypes.Role, userRole));
                //}
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                //var creds = new SigningCredentials(authSigningKey,SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                       issuer: _configuration["JWT:ValidIssuer"],
                       audience: _configuration["JWT:ValidAudience"],
                       expires: DateTime.Now.AddHours(1),
                       claims: Authclaims,
                       signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                       );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
           

        }

    }
}








