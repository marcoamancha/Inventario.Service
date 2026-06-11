using Inventario.Service.Dominio.General;
using Inventario.Service.Dominio.Modelos.Producto;

namespace Inventario.Service.Dominio.Interfaces.Productos
{
    /// <summary>
    /// Puerto de entrada para casos de uso de productos
    /// </summary>
    public interface IProductoUseCases
    {
        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        Task<IEnumerable<ProductoModelo>> ObtenerProductosAsync();

        /// <summary>
        /// Obtiene un producto por su id
        /// </summary>
        Task<ProductoModelo?> ObtenerProductoPorIdAsync(Guid id);

        /// <summary>
        /// Agrega un nuevo producto
        /// </summary>
        Task<ProductoModelo> AgregarProductoAsync(ProductoDto dto);

        /// <summary>
        /// Actualiza un producto existente
        /// </summary>
        Task<ProductoModelo> ActualizarProductoAsync(Guid id, ProductoDto dto);

        /// <summary>
        /// Elimina un producto por su id
        /// </summary>
        Task EliminarProductoAsync(Guid id);
    }
}
