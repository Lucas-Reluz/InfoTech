using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoTech.src.modelos
{
    [Table("tb_videos")]
    public class VideoModelo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Titulo { get; set; }

        [Required, StringLength(300)]
        public string Descricao { get; set; }

        [Required]
        public string Link { get; set; }
    }
}
