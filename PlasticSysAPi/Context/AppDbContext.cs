using Microsoft.EntityFrameworkCore;
using PlasticSYS.Models;

namespace PlasticSysAPi.Context
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Definicion de los DbSet para las entidades 
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venta> Ventas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Configuracion de las tablas y relaciones si es necesario
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
           
            // Configuracion de las relaciones para la entidad Documento
            

            modelBuilder.Entity<Venta>()
            .HasOne(i => i.Cliente) // Un documento tiene un Municipio
            .WithMany(m => m.Ventas) // Un Municipio tiene muchos documentos
            .HasForeignKey(i => i.ClienteId);
        }
    }
}
