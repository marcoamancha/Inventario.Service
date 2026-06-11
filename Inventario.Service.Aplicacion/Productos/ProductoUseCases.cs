using Inventario.Service.Dominio.General;
using Inventario.Service.Dominio.Interfaces.Productos;
using Inventario.Service.Dominio.Modelos.Producto;

namespace Inventario.Service.Aplicacion.Productos
{
    /// <summary>
    /// Clase con la logica de negocio para productos
    /// </summary>
    public class ProductoUseCases : IProductoUseCases
    {
        /// <summary>
        /// Instancia para interfaz del repositorio de productos
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
        public async Task<IEnumerable<ProductoModelo>> ObtenerProductosAsync()
        {
            return await productoRepository.ObtenerTodosAsync();
        }

        /// <summary>
        /// Obtiene un producto por su id
        /// </summary>
        public async Task<ProductoModelo?> ObtenerProductoPorIdAsync(Guid id)
        {
            return await productoRepository.ObtenerPorIdAsync(id);
        }

        /// <summary>
        /// Agrega un nuevo producto a partir de un DTO
        /// </summary>
        public async Task<ProductoModelo> AgregarProductoAsync(ProductoDto dto)
        {
            var producto = new ProductoModelo(
                Guid.NewGuid(),
                dto.Nombre,
                dto.Descripcion,
                dto.Categoria,
                dto.Imagen,
                dto.Precio,
                dto.StockCantidad,
                DateTime.UtcNow,
                DateTime.UtcNow);

            await productoRepository.AgregarAsync(producto);
            return producto;
        }

        /// <summary>
        /// Actualiza un producto existente a partir de un DTO
        /// </summary>
        public async Task<ProductoModelo> ActualizarProductoAsync(Guid id, ProductoDto dto)
        {
            var producto = new ProductoModelo(
                id,
                dto.Nombre,
                dto.Descripcion,
                dto.Categoria,
                dto.Imagen,
                dto.Precio,
                dto.StockCantidad,
                DateTime.UtcNow,
                DateTime.UtcNow);

            await productoRepository.ActualizarAsync(producto);
            return producto;
        }

        /// <summary>
        /// Elimina un producto por su id
        /// </summary>
        public async Task EliminarProductoAsync(Guid id)
        {
            await productoRepository.EliminarAsync(id);
        }
    }
}
