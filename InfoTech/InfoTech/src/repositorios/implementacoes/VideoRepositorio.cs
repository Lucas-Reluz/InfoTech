using InfoTech.src.data;
using InfoTech.src.dtos;
using InfoTech.src.modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoTech.src.repositorios.implementacoes
{
    public class VideoRepositorio : IVideo
    {
        #region Atributos
        private readonly InfoTechContext _contexto;
        #endregion

        #region Construtores
        public VideoRepositorio(InfoTechContext contexto)
        {
            _contexto = contexto;
        }
        #endregion
        public async Task AtualizarVideoAsync(AtualizarVideoDTO video)
        {
            var _video = await PegarVideoPeloIdAsync(video.Id);
            _video.Titulo = video.Titulo;
            _video.Descricao = video.Descricao;
            _video.Link = video.Link;
            await _contexto.SaveChangesAsync();
        }

        public async Task DeletarVideoAsync(int id)
        {
            _contexto.Videos.Remove(await PegarVideoPeloIdAsync(id));
            await _contexto.SaveChangesAsync();
        }

        public async Task NovoVideoAsync(VideoDTO video)
        {
            await _contexto.Videos.AddAsync(new VideoModelo
            {
               Titulo = video.Titulo,
               Descricao = video.Descricao,
               Link = video.Link,
            });
            await _contexto.SaveChangesAsync();
        }

        public async Task<List<VideoModelo>> PegarTodosOsVideosAsync()
        {
            return await _contexto.Videos.ToListAsync();
        }

        public async Task<VideoModelo> PegarVideoPeloIdAsync(int id)
        {
            return await _contexto.Videos.FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}
