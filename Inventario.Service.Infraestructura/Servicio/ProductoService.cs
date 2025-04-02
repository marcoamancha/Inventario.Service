using Inventario.Service.Dominio.Interfaces.Productos;
using Inventario.Service.Dominio.Modelos.Producto;
using Inventario.Service.Infraestructura.Contextos;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Service.Infraestructura.Servicio
{
    public class ProductoService : IProductoRepository
    {
        /// <summary>
        /// Objeto de inventario
        /// </summary>
        private InventarioContexto inventarioContexto;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="inventarioContexto">Inyeccion del objeto de inventario</param>
        public ProductoService(InventarioContexto inventarioContexto)
        {
            this.inventarioContexto = inventarioContexto;
        }

        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        /// <returns>Lista de productos</returns>
        public async Task<List<ProductoModelo>> ObtenerTodosAsync()
        {
            return await inventarioContexto.Productos.ToListAsync();
        }

        /// <summary>
        /// Agregar un nuevo producto
        /// </summary>
        /// <param name="producto">Datos del producto</param>
        /// <returns>Identificacion producto agregado</returns>
        public async Task AgregarAsync(ProductoModelo producto)
        {
            producto.ProductoId = Guid.NewGuid();
            await inventarioContexto.Productos.AddAsync(producto);
            await inventarioContexto.SaveChangesAsync();
        }

        /// <summary>
        /// Actualizar un producto
        /// </summary>
        /// <param name="producto">Datos del producto</param>
        /// <returns>Identificacion producto actualizado</returns>
        public async Task ActualizarAsync(ProductoModelo producto)
        {
            var existente = await inventarioContexto.Productos.AsNoTracking().FirstOrDefaultAsync(p => p.ProductoId == producto.ProductoId);

            if (existente == null)
                throw new KeyNotFoundException("El producto no existe");

            inventarioContexto.Productos.Update(producto);
            await inventarioContexto.SaveChangesAsync();
        }

        /// <summary>
        /// Obtiene un producto por su id
        /// </summary>
        /// <param name="id">Identificacion del producto</param>
        /// <returns>Producto</returns>
        public async Task<ProductoModelo?> ObtenerPorIdAsync(Guid id)
        {
            return await inventarioContexto.Productos.FirstOrDefaultAsync(p => p.ProductoId == id);    
        }

        /// <summary>
        /// Eliminar un prooducto
        /// </summary>
        /// <param name="id">Identificacion del producto</param>
        /// <returns>Identificacion prooducto eliminado</returns>
        public async Task EliminarAsync(Guid id)
        {
            var product = await ObtenerPorIdAsync(id);
            if (product != null)
            {
                inventarioContexto.Productos.Remove(product);
                await inventarioContexto.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Actualiza stock de productos
        /// </summary>
        /// <param name="productoId">Identificacion del producto</param>
        /// <param name="nuevaCantidad">Nueva cantidad</param>
        public async Task ActualizarStockAsync(Guid productoId, int nuevaCantidad)
        {
            var producto = await inventarioContexto.Productos.FindAsync(productoId);
            if (producto != null)
            {
                producto.StockCantidad = nuevaCantidad;
                await inventarioContexto.SaveChangesAsync();
            }
        }
    }
}
