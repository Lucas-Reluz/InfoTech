using InfoTech.src.dtos;
using InfoTech.src.modelos;
using InfoTech.src.repositorios;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InfoTech.src.servicos.implementacoes
{
    public class AutenticacaoServicos : IAutenticacao
    {
        private readonly IUsuario _repositorio;
        public IConfiguration Settings { get; }

        public AutenticacaoServicos(IUsuario repositorio, IConfiguration settings)
        {
            _repositorio = repositorio;
            Settings = settings;
        }

        public string CodificarSenha(string senha)
        {
            var bytes = Encoding.UTF8.GetBytes(senha);
            return Convert.ToBase64String(bytes);
        }

        public async Task CriarUsuarioSemDuplicarAsync(NovoUsuarioDTO dto)
        {
            var usuario = await _repositorio.PegarUsuarioPeloEmailAsync(dto.Email);
            if (usuario != null) throw new Exception("Esse email já esta sendo utilizado! Coloque outro");
            dto.Senha = CodificarSenha(dto.Senha);
            await _repositorio.NovoUsuarioAsync(dto);
        }

        public string GerarToken(UsuarioModelo usuario)
        {
            var tokenManipulador = new JwtSecurityTokenHandler();
            var chave = Encoding.ASCII.GetBytes(Settings["Settings:Secret"]);
            var tokenDescricao = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
            new Claim[]
            {
            new Claim(ClaimTypes.Email, usuario.ToString()),
            new Claim(ClaimTypes.Role, usuario.Tipo.ToString())
            }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(chave),
            SecurityAlgorithms.HmacSha256Signature
            )
            };
            var token = tokenManipulador.CreateToken(tokenDescricao);
            return tokenManipulador.WriteToken(token);
        }

        public async Task<AutorizacaoDTO> PegarAutorizacaoAsync(AutenticacaoDTO dto)
        {
            var usuario = await _repositorio.PegarUsuarioPeloEmailAsync(dto.Email);
            if (usuario == null) throw new Exception("Usuario não foi encontrado");
            if (usuario.Senha != CodificarSenha(dto.Senha)) throw new Exception("A senha está incorreta");
            return new AutorizacaoDTO(usuario.Id, usuario.Email, usuario.Tipo,
            GerarToken(usuario));
        }
    }
}
