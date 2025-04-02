using Inventario.Service.Dominio.Interfaces.Productos;
using Inventario.Service.Dominio.Modelos.Producto;

namespace Inventario.Service.Aplicacion.Productos
{
    /// <summary>
    /// Clase con la logica de negocio para productos
    /// </summary>
    public class ProductoUseCases
    {
        /// <summary>
        /// Instancia para interfaz del servicio de productos
        /// </summary>
        private readonly IProductoRepository productoRepository;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ProductoUseCases(IProductoRepository productoRepository)
        {
            this.productoRepository = productoRepository;
        }

        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        /// <returns>Lista de productos</returns>
        public async Task<IEnumerable<ProductoModelo>> ObtenerProductosAsync()
        {
            return await productoRepository.ObtenerTodosAsync();
        }

        /// <summary>
        /// Obtiene un producto por su id
        /// </summary>
        /// <param name="id">Identificacion del producto</param>
        /// <returns>Producto</returns>
        public async Task<ProductoModelo?> ObtenerProductoPorIdAsync(Guid id)
        {
            return await productoRepository.ObtenerPorIdAsync(id);
        }

        /// <summary>
        /// Agregar un nuevo producto
        /// </summary>
        /// <param name="producto">Datos del producto</param>
        /// <returns>Identificacion producto agregado</returns>
        public async Task AgregarProductoAsync(ProductoModelo product)
        {
            await productoRepository.AgregarAsync(product);
        }

        /// <summary>
        /// Actualizar un producto
        /// </summary>
        /// <param name="producto">Datos del producto</param>
        /// <returns>Identificacion producto actualizado</returns>
        public async Task ActualizarProductoAsync(ProductoModelo product)
        {
            await productoRepository.ActualizarAsync(product);
        }

        /// <summary>
        /// Eliminar un prooducto
        /// </summary>
        /// <param name="id">Identificacion del producto</param>
        /// <returns>Identificacion prooducto eliminado</returns>
        public async Task EliminarProductoAsync(Guid id)
        {
            await productoRepository.EliminarAsync(id);
        }
    }
}
