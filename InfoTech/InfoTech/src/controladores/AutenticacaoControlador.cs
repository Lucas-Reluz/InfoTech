using InfoTech.src.dtos;
using InfoTech.src.servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace InfoTech.src.controladores
{
    [ApiController]
    [Route("api/Autenticacao")]
    [Produces("application/json")]
    public class AutenticacaoControlador : ControllerBase
    {
        private readonly IAutenticacao _repositorio;

        public AutenticacaoControlador(IAutenticacao repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Autenticar([FromBody] AutenticacaoDTO autenticacao)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var autorizacao = await _repositorio.PegarAutorizacaoAsync(autenticacao);
                return Ok(autorizacao);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
