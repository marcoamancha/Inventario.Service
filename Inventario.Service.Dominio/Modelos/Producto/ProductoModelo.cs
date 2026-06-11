using System.ComponentModel.DataAnnotations;
namespace Inventario.Service.Dominio.Modelos.Producto
{
    /// <summary>
    /// Modelo de dominio para productos
    /// </summary>
    public class ProductoModelo
    {
        public Guid ProductoId { get; private set; }
        public string? Nombre { get; private set; }
        public string? Descripcion { get; private set; }
        public string? Categoria { get; private set; }
        public string? Imagen { get; private set; }
        public decimal Precio { get; private set; }
        public int StockCantidad { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public ProductoModelo(Guid productoId, string? nombre, string? descripcion, string? categoria, string? imagen, decimal precio, int stockCantidad, DateTime createdAt, DateTime updatedAt)
        {
            ProductoId = productoId;
            Nombre = nombre;
            Descripcion = descripcion;
            Categoria = categoria;
            Imagen = imagen;
            Precio = precio;
            StockCantidad = stockCantidad;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public void ActualizarStock(int nuevoStock)
        {
            StockCantidad = nuevoStock;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
