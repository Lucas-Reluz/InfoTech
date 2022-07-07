using InfoTech.src.data;
using InfoTech.src.dtos;
using InfoTech.src.modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTech.src.repositorios.implementacoes
{
    public class UsuarioRepositorio : IUsuario
    {
        #region Atributos
        private readonly InfoTechContext _contexto;
        #endregion

        #region Construtores
        public UsuarioRepositorio(InfoTechContext contexto)
        {
            _contexto = contexto;
        }
        #endregion
        public async Task AtualizarUsuarioAsync(AtualizarUsuarioDTO usuario)
        {
            var _usuario = await PegarUsuarioPeloIdAsync(usuario.Id);
            _usuario.Nome = usuario.Nome;
            _usuario.Senha = usuario.Senha;
            _usuario.Endereco = usuario.Endereco;
            await _contexto.SaveChangesAsync();
        }

        public async Task DeletarUsuarioAsync(int id)
        {
            _contexto.Usuarios.Remove(await PegarUsuarioPeloIdAsync(id));
            await _contexto.SaveChangesAsync();
        }

        public async Task NovoUsuarioAsync(NovoUsuarioDTO usuario)
        {
            await _contexto.Usuarios.AddAsync(new UsuarioModelo
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                Endereco = usuario.Endereco,
            });
            await _contexto.SaveChangesAsync();
        }

        public async Task<List<UsuarioModelo>> PegarTodosOsUsuariosAsync()
        {
            return await _contexto.Usuarios.ToListAsync();
        }

        public async Task<List<UsuarioModelo>> PegarUsuarioPeloEmailAsync(string email)
        {
            return await _contexto.Usuarios.Where(u => u.Email.Contains(email)).ToListAsync();
        }

        public async Task<UsuarioModelo> PegarUsuarioPeloIdAsync(int id)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}