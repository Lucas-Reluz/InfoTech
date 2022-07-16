using InfoTech.src.dtos;
using InfoTech.src.repositorios;
using InfoTech.src.servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace InfoTech.src.controladores
{
    [ApiController]
    [Route("api/Usuarios")]
    [Produces("application/json")]
    public class UsuarioControlador : ControllerBase
    {
        private readonly IUsuario _repositorio;
        public readonly IAutenticacao _servicos;

        public UsuarioControlador(IUsuario repositorio, IAutenticacao servicos)
        {
            _repositorio = repositorio;
            _servicos = servicos;
        }

        [HttpGet("id/{idUsuario}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> PegarUsuarioPeloId([FromRoute] int idUsuario) 
        {
            var usuario = await _repositorio.PegarUsuarioPeloIdAsync(idUsuario);

            if (usuario == null) return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> NovoUsuarioAsync([FromBody] NovoUsuarioDTO usuarioNovo)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                await _servicos.CriarUsuarioSemDuplicarAsync(usuarioNovo);

                return Created($"api/Usuarios/email/{usuarioNovo.Email}", usuarioNovo);
            }
            catch (Exception ext)
            {
                return Unauthorized(ext.Message);
            }
        }
    }
}
