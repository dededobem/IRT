using IRT.Application.Interfaces;
using IRT.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRT.Api.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    public class NeighborhoodController : ApiController
    {
        private readonly IAppNeighborhood _appNeighborhood;
        public NeighborhoodController(IAppNeighborhood appNeighborhood)
        {
            _appNeighborhood = appNeighborhood;
        }
        // GET: api/<NeighborhoodController>
        [HttpGet]
        public async Task<IEnumerable<Neighborhood>> Get()
        {
            return await _appNeighborhood.GetAll();
        }

        // GET api/<NeighborhoodController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NeighborhoodController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NeighborhoodController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NeighborhoodController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
