using BM.Core.Shared.ModelViews;
using BM.Manager.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BravosMaquis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoManager manager;
        private readonly ILogger<JogosController> logger;

        public JogosController(IJogoManager _manager, ILogger<JogosController> logger)
        {
            manager = _manager;
            this.logger = logger;
        }
        // GET: api/<JogosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                logger.LogInformation("Requisição de Jogos");
                var result=await manager.GetAllJogosAsync();
                if(result is not null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        // GET api/<JogosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                logger.LogInformation("Requisição de jogo");
                var result = await manager.GetJogoAsync(id);
                if (result is not null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // POST api/<JogosController>
        [HttpPost]
        public async Task<IActionResult> Post(NovoJogo novoJogo)
        {
            logger.LogInformation("Foi requisitado a criação dé um novo jogo");
             var result= await manager.InsertJogoAsync(novoJogo);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        // PUT api/<JogosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(AtualizarJogo atualizarJogo)
        {
            try
            {
                var result = await manager.UpdateJogoAsync(atualizarJogo);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/<JogosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await manager.DeletarJogoAsync(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
