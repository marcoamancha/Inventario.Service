using Inventario.Service.Dominio.General;
using Inventario.Service.Dominio.Interfaces.Productos;
using Inventario.Service.Dominio.Modelos.Producto;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Service.Api.Controllers.Productos
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        /// <summary>
        /// Puerto de entrada del caso de uso de productos
        /// </summary>
        private readonly IProductoUseCases productoUseCases;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="productoUseCases">Inyeccion del caso de uso de producto</param>
        public ProductoController(IProductoUseCases productoUseCases)
        {
            this.productoUseCases = productoUseCases;
        }

        /// <summary>
        /// Api para obtener todos los productos
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ObtenerProductos()
        {
            try
            {
                IEnumerable<ProductoModelo> productos = await productoUseCases.ObtenerProductosAsync();
                return Ok(new InventarioRespuesta<IEnumerable<ProductoModelo>>(productos));
            }
            catch (Exception ex)
            {
                return BadRequest(new InventarioRespuesta<Exception>(ex, false, ex.Message));
            }
        }

        /// <summary>
        /// Api para obtener un producto por id
        /// </summary>
        /// <param name="id">Identificacion del producto</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerProductoPorId(Guid id)
        {
            try
            {
                ProductoModelo? producto = await productoUseCases.ObtenerProductoPorIdAsync(id);
                if (producto == null)
                    return NotFound(new InventarioRespuesta<string>("", false, "Producto no encontrado"));
                return Ok(new InventarioRespuesta<ProductoModelo>(producto));
            }
            catch (Exception ex)
            {
                return BadRequest(new InventarioRespuesta<Exception>(ex, false, ex.Message));
            }
        }

        /// <summary>
        /// Api para registrar un producto
        /// </summary>
        /// <param name="dto">Datos del producto</param>
        [HttpPost]
        public async Task<IActionResult> AgregarProducto([FromBody] ProductoDto dto)
        {
            try
            {
                var producto = await productoUseCases.AgregarProductoAsync(dto);
                return CreatedAtAction(nameof(ObtenerProductoPorId), new { id = producto.ProductoId }, new InventarioRespuesta<ProductoModelo>(producto));
            }
            catch (Exception ex)
            {
                return BadRequest(new InventarioRespuesta<Exception>(ex, false, ex.Message));
            }
        }

        /// <summary>
        /// Api para actualizar un producto
        /// </summary>
        /// <param name="id">Identificacion del producto</param>
        /// <param name="dto">Datos del producto</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarProducto(Guid id, [FromBody] ProductoDto dto)
        {
            try
            {
                var producto = await productoUseCases.ActualizarProductoAsync(id, dto);
                return Ok(new InventarioRespuesta<ProductoModelo>(producto));
            }
            catch (Exception ex)
            {
                return BadRequest(new InventarioRespuesta<Exception>(ex, false, ex.Message));
            }
        }

        /// <summary>
        /// Api para eliminar un producto
        /// </summary>
        /// <param name="id">Identificacion del producto</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarProducto(Guid id)
        {
            try
            {
                await productoUseCases.EliminarProductoAsync(id);
                return Ok(new InventarioRespuesta<Guid>(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new InventarioRespuesta<Exception>(ex, false, ex.Message));
            }
        }
    }
}
