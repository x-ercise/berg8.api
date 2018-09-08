using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace berg8.api.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Token() 
        {
            var header = Request.Headers["Authorization"];

            if (header.ToString().StartsWith("Basic"))
            {
                var credValue = header.ToString().Substring("Basic ".Length).Trim();
                string userCredential = Encoding.UTF8.GetString(Convert.FromBase64String(credValue));
                string[] param = userCredential.Split(':');

                bool isUser = (param[0] == "REQUESTOR") || (param[0] == "APPROVER");
                bool isPass = (param[0] == "pass");
                if (isUser && isPass)// write database authroized
                {
                    var userClaim = new[] { 
                        new Claim(ClaimTypes.Name, "x-ercise"),
                        new Claim(ClaimTypes.Email, "x.fronzen@gmail.com"),
                        new Claim(ClaimTypes.MobilePhone, "0839997169")
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ApiSymmetric.PrivateKey));
                    var signInCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                    
                    var token = new JwtSecurityToken(
                        issuer: "localhost:5001",
                        audience: "localhost:5001",
                        expires: DateTime.Now.AddMinutes(5),
                        claims: userClaim,
                        signingCredentials: signInCredential
                    );
                    
                    string strToken = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(strToken);
                }
            } else {

            }
            return BadRequest("user or password invalid.");
        }
    }
}
