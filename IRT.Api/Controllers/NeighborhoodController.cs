using IRT.Api.Models;
using IRT.Application.Interfaces;
using IRT.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IRT.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class NeighborhoodController : ControllerBase
    {
        private readonly IAppNeighborhood _appNeighborhood;
        public NeighborhoodController(IAppNeighborhood appNeighborhood) => _appNeighborhood = appNeighborhood;

        /// <summary>
        /// Consulta de Bairros
        /// </summary>
        /// <remarks>
        /// Serviço responsável por retornar os bairros existentes em Salvador
        /// </remarks>
        /// <param name="parameter">Objeto do tipo RequestNeighborhood que possui os parâmetros Nome e quantidade de resultados</param>
        /// <returns></returns>
        // GET api/<NeighborhoodController>
        [HttpGet]
        [Route("/api/Neighborhood/GetByName")]
        public async Task<IActionResult> Get([FromQuery] RequestNeighborhood parameter) =>
            new OkObjectResult(await _appNeighborhood.GetByName(parameter.Name, parameter.MaxResults));        

        /// <summary>
        /// Retornar todos os Bairros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/Neighborhood/GetAll")]
        public async Task<IActionResult> Get() => new OkObjectResult(await _appNeighborhood.GetAll());
        
        /// <summary>
        /// Cadastro de um novo Bairro
        /// </summary>
        /// <remarks>
        /// Serviço responsável por cadastrar um novo bairro na base de dados da APLICAÇÃO
        /// </remarks>
        /// <param name="neighborhood">Dados do bairro</param>
        /// <returns></returns>
        // POST api/<NeighborhoodController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NeighborhoodViewModel neighborhood) => 
            Ok(await _appNeighborhood.Add(neighborhood));
        
    }
}
