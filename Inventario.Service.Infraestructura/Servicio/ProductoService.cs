using Inventario.Service.Dominio.Interfaces.Productos;
using Inventario.Service.Dominio.Modelos.Producto;
using Inventario.Service.Infraestructura.Contextos;
using Inventario.Service.Infraestructura.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Service.Infraestructura.Servicio
{
    public class ProductoService : IProductoRepository
    {
        /// <summary>
        /// Objeto de inventario
        /// </summary>
        private readonly InventarioContexto inventarioContexto;

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
        public async Task<List<ProductoModelo>> ObtenerTodosAsync()
        {
            var entidades = await inventarioContexto.Productos.ToListAsync();
            return entidades.Select(MapearAModelo).ToList();
        }

        /// <summary>
        /// Obtiene un producto por su id
        /// </summary>
        public async Task<ProductoModelo?> ObtenerPorIdAsync(Guid id)
        {
            var entidad = await inventarioContexto.Productos.FirstOrDefaultAsync(p => p.ProductoId == id);
            return entidad is null ? null : MapearAModelo(entidad);
        }

        /// <summary>
        /// Agrega un nuevo producto
        /// </summary>
        public async Task AgregarAsync(ProductoModelo producto)
        {
            var entidad = MapearAEntidad(producto);
            await inventarioContexto.Productos.AddAsync(entidad);
            await inventarioContexto.SaveChangesAsync();
        }

        /// <summary>
        /// Actualiza un producto existente
        /// </summary>
        public async Task ActualizarAsync(ProductoModelo producto)
        {
            var existente = await inventarioContexto.Productos.AsNoTracking().FirstOrDefaultAsync(p => p.ProductoId == producto.ProductoId);

            if (existente == null)
                throw new KeyNotFoundException("El producto no existe");

            var entidad = MapearAEntidad(producto);
            inventarioContexto.Productos.Update(entidad);
            await inventarioContexto.SaveChangesAsync();
        }

        /// <summary>
        /// Elimina un producto por su id
        /// </summary>
        public async Task EliminarAsync(Guid id)
        {
            var entidad = await inventarioContexto.Productos.FindAsync(id);
            if (entidad != null)
            {
                inventarioContexto.Productos.Remove(entidad);
                await inventarioContexto.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Actualiza el stock de un producto
        /// </summary>
        public async Task ActualizarStockAsync(Guid productoId, int nuevaCantidad)
        {
            var entidad = await inventarioContexto.Productos.FindAsync(productoId);
            if (entidad != null)
            {
                entidad.StockCantidad = nuevaCantidad;
                entidad.UpdatedAt = DateTime.UtcNow;
                await inventarioContexto.SaveChangesAsync();
            }
        }

        private static ProductoModelo MapearAModelo(ProductoEntidad e) =>
            new(e.ProductoId, e.Nombre, e.Descripcion, e.Categoria, e.Imagen, e.Precio, e.StockCantidad, e.CreatedAt, e.UpdatedAt);

        private static ProductoEntidad MapearAEntidad(ProductoModelo m) =>
            new()
            {
                ProductoId = m.ProductoId,
                Nombre = m.Nombre,
                Descripcion = m.Descripcion,
                Categoria = m.Categoria,
                Imagen = m.Imagen,
                Precio = m.Precio,
                StockCantidad = m.StockCantidad,
                CreatedAt = m.CreatedAt,
                UpdatedAt = m.UpdatedAt
            };
    }
}
