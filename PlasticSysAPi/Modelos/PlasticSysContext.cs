using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace PlasticSYS.Models
{
    public class PlasticSysContext : DbContext
    {
        public PlasticSysContext(DbContextOptions<PlasticSysContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Marca> Marcas { get; set; }
    }
}
