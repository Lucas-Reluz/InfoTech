using InfoTech.src.dtos;
using InfoTech.src.modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoTech.src.repositorios.implementacoes
{
    public class ContatoRepositorio : IContato
    {
        public Task DeletarContatoAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task NovoContatoAsync(ContatoDTO contato)
        {
            throw new System.NotImplementedException();
        }

        public Task<ContatoModelo> PegarContatoPeloIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ContatoModelo>> PegarContatoPorPesquisaAsync(string emailDoUsuario, string assunto)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ContatoModelo>> PegarTodosOsContatosAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
