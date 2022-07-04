using System.ComponentModel.DataAnnotations;

namespace InfoTech.src.dtos
{
    public class VideoDTO
    {
        [Required, StringLength(100)]
        public string Titulo { get; set; }

        [StringLength(300)]
        public string Descricao { get; set; }

        [Required]
        public string Link { get; set; }

        public VideoDTO(string titulo, string descricao, string link)
        {
            Titulo = titulo;
            Descricao = descricao;
            Link = link;
        }
    }

    public class AtualizarVideoDTO
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Titulo { get; set; }

        [StringLength(300)]
        public string Descricao { get; set; }

        [Required]
        public string Link { get; set; }

        public AtualizarVideoDTO(int id, string titulo, string descricao, string link)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Link = link;
        }
    }
}
