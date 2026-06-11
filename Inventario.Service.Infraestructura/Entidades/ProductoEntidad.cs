using System.ComponentModel.DataAnnotations;

namespace Inventario.Service.Infraestructura.Entidades
{
    /// <summary>
    /// Entidad de persistencia para productos (EF Core)
    /// </summary>
    public class ProductoEntidad
    {
        [Key]
        public Guid ProductoId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Categoria { get; set; }
        public string? Imagen { get; set; }
        public decimal Precio { get; set; }
        public int StockCantidad { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
