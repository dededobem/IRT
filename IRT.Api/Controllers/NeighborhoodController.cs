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
    public class NeighborhoodController : ControllerBase
    {
        private readonly IAppNeighborhood _appNeighborhood;
        public NeighborhoodController(IAppNeighborhood appNeighborhood) => _appNeighborhood = appNeighborhood;
        
        // GET api/<NeighborhoodController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Parameter<RequestNeighborhood> parameter)
        {
            return new OkObjectResult(await _appNeighborhood.GetByName(parameter.Filter?.Name, parameter.MaxResults));
        }

        // POST api/<NeighborhoodController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NeighborhoodViewModel neighborhood)
        {
            return Ok(await _appNeighborhood.Add(neighborhood));
        }
    }
}
