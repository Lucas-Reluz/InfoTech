using InfoTech.src.tipos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoTech.src.modelos
{
    [Table("tb_usuarios")]
    public class UsuarioModelo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required, StringLength(100)]
        public string Email { get; set; }

        [Required, StringLength(40)]
        public string Senha { get; set; }

        public string Endereco { get; set; }

        [Required]
        public TipoUsuario Tipo { get; set; }
    }
}
