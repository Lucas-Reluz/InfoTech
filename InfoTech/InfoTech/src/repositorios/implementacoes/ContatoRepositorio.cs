using InfoTech.src.data;
using InfoTech.src.dtos;
using InfoTech.src.modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTech.src.repositorios.implementacoes
{
    public class ContatoRepositorio : IContato
    {
        #region Atributos
        private readonly InfoTechContext _contexto;
        #endregion

        #region Construtores
        public ContatoRepositorio(InfoTechContext contexto)
        {
            _contexto = contexto;
        }
        #endregion
        public async Task DeletarContatoAsync(int id)
        {
            _contexto.Contatos.Remove(await PegarContatoPeloIdAsync(id));
            await _contexto.SaveChangesAsync();
        }

        public async Task NovoContatoAsync(ContatoDTO contato)
        {
            await _contexto.Contatos.AddAsync(new ContatoModelo
            {
               Nome = contato.Nome,
               Email = contato.Email,
               Assunto = contato.Assunto,
               Comentario = contato.Comentario,
               Foto = contato.Foto,
            });
            await _contexto.SaveChangesAsync();
        }

        public async Task<ContatoModelo> PegarContatoPeloIdAsync(int id)
        {
            return await _contexto.Contatos.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<ContatoModelo>> PegarContatoPorPesquisaAsync(string emailDoUsuario, string assuntoDoContato)
        {
            switch(emailDoUsuario, assuntoDoContato)
            {
                case(null, null):
                    return await PegarTodosOsContatosAsync();

                case ( _, null):
                    return await _contexto.Contatos
                    .Where(c => c.Email == emailDoUsuario).ToListAsync();

                case (null, _):
                    return await _contexto.Contatos
                    .Where(c => c.Assunto.Contains(assuntoDoContato)).ToListAsync();

                case (_, _):
                    return await _contexto.Contatos
                        .Where(c => c.Email == emailDoUsuario 
                        | c.Assunto.Contains(assuntoDoContato)).ToListAsync();
            }
        }

        public async Task<List<ContatoModelo>> PegarTodosOsContatosAsync()
        {
           return await _contexto.Contatos.ToListAsync();
        }
    }
}
