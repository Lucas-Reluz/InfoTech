using InfoTech.src.modelos;
using Microsoft.EntityFrameworkCore;

namespace InfoTech.src.data
{
    public class InfoTechContext : DbContext
    {
        public DbSet<UsuarioModelo> Usuarios { get; set; }
        public DbSet<VideoModelo> Videos { get; set; }
        public DbSet<ContatoModelo> Contatos { get; set; }

        public InfoTechContext(DbContextOptions<InfoTechContext> opt) : base(opt)
        {

        }
    }
}
