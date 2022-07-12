using InfoTech.src.tipos;
using System.ComponentModel.DataAnnotations;

namespace InfoTech.src.dtos
{
    public class AutenticacaoDTO
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Senha { get; set; }

        public AutenticacaoDTO(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }
    }

    public class AutorizacaoDTO
    {
        [Required]
        public int Id { get; set; }
        public string Email { get; set; }
        public TipoUsuario Tipo { get; set; }
        public string Token { get; set; }
        public AutorizacaoDTO(int id, string email, TipoUsuario tipo, string token)
        {
            Id = id;
            Email = email;
            Tipo = tipo;
            Token = token;
        }
    }
}
