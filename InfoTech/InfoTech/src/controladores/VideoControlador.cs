using InfoTech.src.dtos;
using InfoTech.src.repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InfoTech.src.controladores
{
    [ApiController]
    [Route("api/Videos")]
    [Produces("application/json")]
    public class VideoControlador : ControllerBase
    {
        private readonly IVideo _repositorio;

        public VideoControlador(IVideo repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet("id/{idVideo}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> PegarVideoPeloIdAsync([FromRoute] int idVideo)
        {
            var video = await _repositorio.PegarVideoPeloIdAsync(idVideo);

            if (video == null) return NotFound();

            return Ok(video);
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN, COMUM")]
        public async Task<ActionResult> PegarTodosOsVideosAsync()
        {
            var lista = await _repositorio.PegarTodosOsVideosAsync();

            if (lista.Count < 1) return NoContent();

            return Ok(lista);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> NovoVideoAsync([FromBody] VideoDTO novoVideo)
        {
            if (!ModelState.IsValid) return BadRequest();
            
            await _repositorio.NovoVideoAsync(novoVideo);

            return Created($"api/Videos", novoVideo);

        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> AtualizarVideoAsync([FromBody] AtualizarVideoDTO atualizarVideo)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _repositorio.AtualizarVideoAsync(atualizarVideo);

            return Ok(atualizarVideo);
        }

        [HttpDelete]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> DeletarVideoAsync([FromRoute] int id)
        {
            await _repositorio.DeletarVideoAsync(id);
            return NoContent();
        }
    }
}
