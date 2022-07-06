using InfoTech.src.dtos;
using InfoTech.src.modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoTech.src.repositorios
{
    public interface IUsuario
    {
        Task NovoUsuarioAsync(NovoUsuarioDTO usuario);
        Task AtualizarUsuarioAsync(AtualizarUsuarioDTO usuario);
        Task DeletarUsuarioAsync(int id);

        Task<UsuarioModelo> PegarUsuarioPeloIdAsync(int id);
        Task<List<UsuarioModelo>> PegarUsuarioPeloEmailAsync(string Email);
        Task<List<UsuarioModelo>> PegarTodosOsUsuariosAsync();
    }
}
