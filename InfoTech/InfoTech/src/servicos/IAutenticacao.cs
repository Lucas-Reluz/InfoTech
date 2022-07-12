using InfoTech.src.dtos;
using InfoTech.src.modelos;
using System.Threading.Tasks;

namespace InfoTech.src.servicos
{
    public interface IAutenticacao
    {
        string CodificarSenha(string senha);
        Task CriarUsuarioSemDuplicarAsync(NovoUsuarioDTO dto);
        string GerarToken(UsuarioModelo usuario);
        Task<AutorizacaoDTO> PegarAutorizacaoAsync(AutenticacaoDTO dto);
    }
}
