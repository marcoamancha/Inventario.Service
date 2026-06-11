using Inventario.Service.Infraestructura.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Service.Infraestructura.Contextos
{
    public class InventarioContexto : DbContext
    {
        public InventarioContexto(DbContextOptions<InventarioContexto> options): base(options) { }

        public DbSet<ProductoEntidad> Productos { get; set; }

        public DbSet<TransaccionEntidad> Transacciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductoEntidad>().ToTable("Productos");
            modelBuilder.Entity<ProductoEntidad>()
                .HasKey(p => p.ProductoId);

            modelBuilder.Entity<TransaccionEntidad>().ToTable("Transacciones");
            modelBuilder.Entity<TransaccionEntidad>()
                .HasKey(p => p.TransaccionId);
        }
    }
}
