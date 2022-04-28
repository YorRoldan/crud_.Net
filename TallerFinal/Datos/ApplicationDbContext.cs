using Microsoft.EntityFrameworkCore;
using TallerFinal.Models;

namespace TallerFinal.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Clientes> Clientes { get; set;}
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }

    }
}
