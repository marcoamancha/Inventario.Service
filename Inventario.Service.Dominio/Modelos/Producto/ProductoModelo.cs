using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario.Service.Dominio.Modelos.Producto
{
    /// <summary>
    /// Clase para el modelo de productos
    /// </summary>
    public class ProductoModelo
    {
        [Key]
        public Guid ProductoId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Categoria { get; set; }
        public string? Imagen { get; set; }
        public decimal Precio { get; set; }
        public int StockCantidad { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
