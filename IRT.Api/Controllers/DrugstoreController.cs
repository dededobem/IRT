using IRT.Api.Models;
using IRT.Application.Interfaces;
using IRT.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace IRT.Api.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    public class DrugstoreController : ControllerBase
    {
        private readonly IAppDrugstore _appDrugstore;

        public DrugstoreController(IAppDrugstore appDrugstore) => _appDrugstore = appDrugstore;

        // GET: api/<DrugstoreController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Parameter<RequestDrusgtore> parameter)
        {
            return new OkObjectResult(await _appDrugstore.GetByName(parameter.Filter?.Name, parameter.MaxResults));
        }

        // POST api/<DrugstoreController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DrugstoreViewModel drugstore)
        {
            return Ok(await _appDrugstore.Add(drugstore));
        }

        // PUT api/<DrugstoreController>/5
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] DrugstoreViewModel drugstore)
        {
            return Ok(await _appDrugstore.Update(id, drugstore));
        }

        // DELETE api/<DrugstoreController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _appDrugstore.Delete(id);
        }

        // GET: api/<DrugstoreController>
        [HttpGet("{id_neighborhood}")]
        public async Task<IActionResult> GetByNeighborhood(Guid id_neighborhood, RequestDrugstoreNeighborhood parameter)
        {
            return new OkObjectResult(await _appDrugstore.GetByNeighborhood(id_neighborhood, parameter.flgRoundTheClock));
        }

    }
}
