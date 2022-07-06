using InfoTech.src.dtos;
using InfoTech.src.modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoTech.src.repositorios
{
    public interface IVideo
    {
        Task NovoVideoAsync(VideoDTO video);
        Task DeletarVideoAsync(int id);
        Task AtualizarVideoAsync(AtualizarVideoDTO video);
        Task<VideoModelo> PegarVideoPeloIdAsync(int id);
        Task<List<VideoModelo>> PegarTodosOsVideosAsync();

    }
}
