using BM.Core.Shared.ModelViews;
using BM.Manager.Interfaces;
using BravosMaquis.Models.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BravosMaquis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubeController : ControllerBase
    {
        private readonly IClubeManager _manager;
        private readonly ILogger<ClubeController> logger;

        public ClubeController(IClubeManager manager, ILogger<ClubeController> _logger)
        {
            this._manager = manager;
            logger = _logger;
        }
        // GET: api/<ClubeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var encontrado=await _manager.GetClubesAsync();
            if (encontrado is not null)
                return Ok(encontrado);
            return NotFound();
        }

        // GET api/<ClubeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
               var encontrado=await _manager.GetClubeByIdAsync(id);
                if(encontrado is not null)
                    return Ok(encontrado);
                return NotFound();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // POST api/<ClubeController>
        [HttpPost]
        public async Task<IActionResult> Post(NovoClube clube)
        {
            logger.LogInformation("Foi requisitado a inserção déum Novo Clube");
            var inserido=await _manager.InsertClube(clube);
            return CreatedAtAction(nameof(Get), new { id = inserido.Id }, inserido);
        }

        // PUT api/<ClubeController>/5
        [HttpPut()]
        public async Task<IActionResult> Put(UpdateClube clube)
        {
           
            try
            {
                var atualizado = await _manager.UpdateClube(clube);
                return Ok(atualizado);
            }
            catch (Exception ex)
            {

                return NotFound( ex.Message);
            }
        }

        // DELETE api/<ClubeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _manager.DeleteClube(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
