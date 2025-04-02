using Inventario.Service.Dominio.Modelos.Producto;

namespace Inventario.Service.Dominio.Interfaces.Productos
{
    /// <summary>
    /// Interfaz con metodos para producto
    /// </summary>
    public interface IProductoRepository
    {
        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        /// <returns>Lista de productos</returns>
        Task<List<ProductoModelo>> ObtenerTodosAsync();

        /// <summary>
        /// Obtiene un producto por su id
        /// </summary>
        /// <param name="id">Identificacion del producto</param>
        /// <returns>Producto</returns>
        Task<ProductoModelo?> ObtenerPorIdAsync(Guid id);

        /// <summary>
        /// Agregar un nuevo producto
        /// </summary>
        /// <param name="producto">Datos del producto</param>
        /// <returns>Identificacion producto agregado</returns>
        Task AgregarAsync(ProductoModelo producto);

        /// <summary>
        /// Actualizar un producto
        /// </summary>
        /// <param name="producto">Datos del producto</param>
        /// <returns>Identificacion producto actualizado</returns>
        Task ActualizarAsync(ProductoModelo producto);

        /// <summary>
        /// Eliminar un prooducto
        /// </summary>
        /// <param name="id">Identificacion del producto</param>
        /// <returns>Identificacion prooducto eliminado</returns>
        Task EliminarAsync(Guid id);

        /// <summary>
        /// Actualiza el stock
        /// </summary>
        /// <param name="productoId">Identificacion del producto</param>
        /// <param name="nuevaCantidad">Nueva cantidad</param>
        Task ActualizarStockAsync(Guid productoId, int nuevaCantidad);
    }
}
