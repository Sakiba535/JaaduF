using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class AccountController : ApiController
    {
        [Route("~/security")]
        [HttpPost]
        public IHttpActionResult GetToken(UserInfo user)
        {
            UserInfo loginuser;

            using(LibraryDB dB = new LibraryDB())
            {
                loginuser=dB.Users.SingleOrDefault(u=>u.UserName == user.UserName && u.Password==user.Password);
            }

            if(loginuser is null)
            {
                return BadRequest("Invalid Credentials");
            }


            var key = ConfigurationManager.AppSettings["JwtKey"];
            var issuer = ConfigurationManager.AppSettings["JwtIssuer"];
            var audience = ConfigurationManager.AppSettings["JwtAudience"];

            var securitykey= new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            var credentials= new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var userclaims = new List<Claim>();

            userclaims.Add(new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()));
            userclaims.Add(new Claim (ClaimTypes.Name,loginuser.UserName));
            userclaims.Add(new Claim(ClaimTypes.Role, loginuser.Role));

            var token= new JwtSecurityToken(issuer,audience, userclaims,expires:DateTime.UtcNow.AddDays(1),signingCredentials:credentials);
            var jwt = new JwtSecurityTokenHandler ().WriteToken(token);
            return Ok(jwt);














        }








    }
}
