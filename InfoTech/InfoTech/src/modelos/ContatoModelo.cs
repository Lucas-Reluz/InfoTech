using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoTech.src.modelos
{
    [Table("tb_contatos")]
    public class ContatoModelo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required,StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string Email { get; set; }

        [Required]
        public string Assunto{ get; set; }

        [Required]
        public string Comentario { get; set; }

        public string Foto { get; set; }
    }
}
