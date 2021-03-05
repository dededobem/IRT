using IRT.Application.Interfaces;
using IRT.Application.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IRT.Application.Services
{
    public class AppAuthentication : IAppAuthentication
    {
        private readonly IAppUser _appUser;
        private readonly IConfiguration _configuration;
        public AppAuthentication(IAppUser appUser, IConfiguration configuration)
        {
            _appUser = appUser;
            _configuration = configuration;
        }
        public async Task<AccountViewModel> Authenticate(string login, string password)
        {
            var user = await _appUser.VerifyUser(login, password);
            if (user == null) throw new Exception("Login ou senha inválida.");

            var token = GenerateToken(user);
            user.Password = "";

            return new AccountViewModel{ 
                Name = user.Name, 
                Login = user.Login, 
                Token = token 
            };
        }

        public string GenerateToken(UserViewModel user)
        {            
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Authentication:SecretKey")));
            var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Name)
                }),
                Expires = DateTime.UtcNow.AddDays(_configuration.GetValue<int>("Authentication:Expiration")),
                SigningCredentials = credentials
            };

            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}