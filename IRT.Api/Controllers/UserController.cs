using IRT.Api.Models;
using IRT.Application.Interfaces;
using IRT.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IRT.Api.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IAppUser _appUser;
        public UserController(IAppUser appUser)
        {
            _appUser = appUser;
        }

        // POST api/<UserController>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] UserViewModel dataUser)
        {
            return Ok(await _appUser.Add(dataUser));
        }
    }
}
