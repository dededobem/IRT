using System.Threading.Tasks;
using IRT.Api.Models;
using IRT.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IRT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAppAuthentication _appAuthentication;

        public AuthenticationController(IAppAuthentication appAuthentication)
        {
            _appAuthentication = appAuthentication;
        }

        /// <summary>
        /// Autenticar na aplicação
        /// </summary>
        /// <param name="user">Dados da autenticação</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] RequestAuthentication user)
        {
            return Ok(await _appAuthentication.Authenticate(user.Login, user.Password));
        }        
    }
}
