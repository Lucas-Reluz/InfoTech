using System.ComponentModel.DataAnnotations;

namespace InfoTech.src.dtos
{
    public class ContatoDTO
    {
        [Required, StringLength(100)]
        public string Nome { get; set; }

        [Required, StringLength(100)]
        public string Email { get; set; }

        [Required]
        public string Assunto { get; set; }

        [Required]
        public string Comentario { get; set; }

        public string Foto { get; set; }

        public ContatoDTO(string nome, string email, string assunto, string comentario, string foto)
        {
            Nome = nome;
            Email = email;
            Assunto = assunto;
            Comentario = comentario;
            Foto = foto;
        }
    }
}
