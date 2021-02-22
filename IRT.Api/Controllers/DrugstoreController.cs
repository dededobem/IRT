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

        /// <summary>
        /// Consulta de Farmácias
        /// </summary>
        /// <remarks>
        /// Serviço responsável por retornar as farmácias existentes em Salvador
        /// </remarks>
        /// <param name="parameter">Objeto do tipo RequestDrusgtore que possui os parâmetros Nome e quantidade de resultados</param>
        /// <returns></returns>
        // GET: api/<DrugstoreController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Parameter<RequestDrusgtore> parameter)
        {
            return new OkObjectResult(await _appDrugstore.GetByName(parameter.Filter?.Name, parameter.MaxResults));
        }

        /// <summary>
        /// Cadastro de uma nova Farmácia
        /// </summary>
        /// <remarks>
        /// Serviço responsável por cadastrar uma nova farmácia na base de dados da APLICAÇÃO
        /// </remarks>
        /// <param name="drugstore">Dados da farmácia</param>
        /// <returns></returns>
        // POST api/<DrugstoreController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DrugstoreViewModel drugstore)
        {
            return Ok(await _appDrugstore.Add(drugstore));
        }

        /// <summary>
        /// Edição de uma Farmácia
        /// </summary>
        /// <remarks>
        /// Serviço responsável por editar uma farmácia cadastrada na base de dados da APLICAÇÃO
        /// </remarks>
        /// <param name="id">Identificador da farmácia</param>
        /// <param name="drugstore">Dados da farmácia</param>
        /// <returns></returns>
        // PUT api/<DrugstoreController>/5
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] DrugstoreViewModel drugstore)
        {
            return Ok(await _appDrugstore.Update(id, drugstore));
        }

        /// <summary>
        /// Exclusão de uma Farmácia
        /// </summary>
        /// <remarks>
        /// Serviço responsável por excluir uma farmácia cadastrada na base de dados da APLICAÇÃO
        /// </remarks>
        /// <param name="id">Identificador da farmácia</param>
        /// <returns></returns>
        // DELETE api/<DrugstoreController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _appDrugstore.Delete(id);
        }

        /// <summary>
        /// Consulta de Farmácias por Bairro
        /// </summary>
        /// <remarks>
        /// Serviço responsável por retornar as farmácias existentes em Salvador de acordo com o bairro passado como parâmetro
        /// </remarks>
        /// <param name="id_neighborhood">Identificador do bairro</param>
        /// <param name="parameter">Objeto do tipo RequestDrugstoreNeighborhood que possui o parametro FlgRoundTheClock</param>
        /// <returns></returns>
        // GET: api/<DrugstoreController>/id_neighborhood
        [HttpGet("{id_neighborhood}")]
        public async Task<IActionResult> GetByNeighborhood(Guid id_neighborhood, RequestDrugstoreNeighborhood parameter)
        {
            return new OkObjectResult(await _appDrugstore.GetByNeighborhood(id_neighborhood, parameter.FlgRoundTheClock));
        }

    }
}
