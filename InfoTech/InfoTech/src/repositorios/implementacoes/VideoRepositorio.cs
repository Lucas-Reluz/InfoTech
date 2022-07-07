using InfoTech.src.dtos;
using InfoTech.src.modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoTech.src.repositorios.implementacoes
{
    public class VideoRepositorio : IVideo
    {
        public Task AtualizarVideoAsync(AtualizarVideoDTO video)
        {
            throw new System.NotImplementedException();
        }

        public Task DeletarVideoAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task NovoVideoAsync(VideoDTO video)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<VideoModelo>> PegarTodosOsVideosAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<VideoModelo> PegarVideoPeloIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
