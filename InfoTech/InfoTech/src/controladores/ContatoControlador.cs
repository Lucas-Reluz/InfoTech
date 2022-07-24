using InfoTech.src.dtos;
using InfoTech.src.repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InfoTech.src.controladores
{
    [ApiController]
    [Route("api/Contatos")]
    [Produces("application/json")]
    public class ContatoControlador : ControllerBase
    {
        private readonly IContato _repositorio;

        public ContatoControlador(IContato repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet("id/{idContato}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> PegarContatoPeloId([FromRoute] int id)
        {
            var contato = await _repositorio.PegarContatoPeloIdAsync(id);

            if (contato == null) return NotFound();

            return Ok(contato);
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> PegarTodosOsContatosAsync()
        {
            var lista = await _repositorio.PegarTodosOsContatosAsync();
            
            if (lista.Count < 1) return NoContent();

            return Ok(lista);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> NovoContatoAsync([FromBody] ContatoDTO novoContato)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _repositorio.NovoContatoAsync(novoContato);
            return Created($"api/Contatos", novoContato);
        }
        [HttpDelete]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> DeletarContatoAsync([FromRoute] int id)
        {
            await _repositorio.DeletarContatoAsync(id);
            return NoContent();
        }

        [HttpGet("pesquisa")]
        [Authorize]
        public async Task<ActionResult> PegarContatoPorPesquisaAsync([FromQuery] string emailDoUsuario, [FromQuery] string assunto)
        {
            var lista = await _repositorio.PegarContatoPorPesquisaAsync(emailDoUsuario, assunto);

            if (lista.Count < 1) return NotFound();

            return Ok(lista);
        }
    }
}
