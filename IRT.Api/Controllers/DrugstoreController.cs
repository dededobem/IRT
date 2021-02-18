using IRT.Application.Interfaces;
using IRT.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRT.Api.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    public class DrugstoreController : ApiController
    {
        private readonly IAppDrugstore _appDrugstore;

        public DrugstoreController(IAppDrugstore appDrugstore) => _appDrugstore = appDrugstore;

        // GET: api/<DrugstoreController>
        [HttpGet]
        public async Task<IEnumerable<Drugstore>> Get()
        {
            return await _appDrugstore.GetAll();
        }

        // GET api/<DrugstoreController>/5
        [HttpGet("{id:guid}")]
        public async Task<Drugstore> Get(Guid id)
        {
            return await _appDrugstore.GetById(id);
        }

        // POST api/<DrugstoreController>
        [HttpPost]
        public void Post([FromBody] Drugstore drugstore)
        {
            _appDrugstore.Add(drugstore);
        }

        // PUT api/<DrugstoreController>/5
        [HttpPut]
        public void Put([FromBody] Drugstore drugstore)
        {
            _appDrugstore.Update(drugstore);

        }

        // DELETE api/<DrugstoreController>/5
        [HttpDelete]
        public void Delete([FromBody] Drugstore drugstore)
        {
            _appDrugstore.Delete(drugstore);
        }
    }
}
