using InfoTech.src.dtos;
using InfoTech.src.modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoTech.src.repositorios
{
    public interface IContato
    {
        Task NovoContatoAsync(ContatoDTO contato);
        Task DeletarContatoAsync(int id);

        Task<ContatoModelo> PegarContatoPeloIdAsync(int id);
        Task<List<ContatoModelo>> PegarContatoPorPesquisaAsync(string emailDoUsuario, string assunto);
        Task<List<ContatoModelo>> PegarTodosOsContatosAsync();
    }
}
