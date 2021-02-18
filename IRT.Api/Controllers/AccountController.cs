using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using IRT.Api.Util;
using IRT.Application.Interfaces;
using IRT.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IRT.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAppUser _appUser;
        private readonly IConfiguration _configuration;

        public AccountController(IAppUser appUser, IConfiguration configuration)
        {
            _appUser = appUser;
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] User user)
        {
            //convert password for md5Hash
            user.Password = new HashPassword().CalculateMD5Hash(user.Password);

            var _user = _appUser.VerifyUser(user);
            if (_user == null)
            {
                return BadRequest("Login or password incorrect.");
            }

            var token = GenerateToken(_user);
            _user.Password = "";

            return Ok(new
            {
                name = _user.Name,
                login = _user.Login,
                token = token
            });
        }

        private string GenerateToken(User user, int expireDays = 3)
        {
            var symmetricKey = Convert.FromBase64String(_configuration["Authentication:SecretKey"]);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Name)
                }),
                Expires = DateTime.UtcNow.AddDays(expireDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
