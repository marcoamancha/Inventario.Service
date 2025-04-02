using Inventario.Service.Dominio.Modelos.Producto;
using Inventario.Service.Dominio.Modelos.Transaccion;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Service.Infraestructura.Contextos
{
    public class InventarioContexto : DbContext
    {
        public InventarioContexto(DbContextOptions<InventarioContexto> options): base(options) { }

        public DbSet<ProductoModelo> Productos { get; set; }

        public DbSet<TransaccionModelo> Transacciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductoModelo>().ToTable("Productos");
            modelBuilder.Entity<ProductoModelo>()
                .HasKey(p => p.ProductoId);

            modelBuilder.Entity<TransaccionModelo>().ToTable("Transacciones");
            modelBuilder.Entity<TransaccionModelo>()
                .HasKey(p => p.TransaccionId);

        }
    }
}
