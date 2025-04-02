using Inventario.Service.Dominio.General;
using Inventario.Service.Dominio.Interfaces.Productos;
using Inventario.Service.Dominio.Modelos.Producto;
using Inventario.Service.Dominio.Modelos.Transaccion;

namespace Inventario.Service.Aplicacion.Transacion
{
    /// <summary>
    /// Clase con la logica de negocio para la transaccion
    /// </summary>
    public class RegistrarTransaccionUseCases
    {
        /// <summary>
        /// Instancia para interfaz del servicio de productos
        /// </summary>
        private readonly ITransaccionRepository transaccionRepository;

        /// <summary>
        /// Instancia para interfaz del servicio de productos
        /// </summary>
        private readonly IProductoRepository productoRepository;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="transaccionRepository">Inyeccion del objeto de transaccion</param>
        /// <param name="productoRepository">Inyeccion del objeto de producto</param>
        public RegistrarTransaccionUseCases(ITransaccionRepository transaccionRepository, IProductoRepository productoRepository)
        {
            this.transaccionRepository = transaccionRepository;
            this.productoRepository = productoRepository;
        }


        /// <summary>
        /// Metodo para registrar la transaccion
        /// </summary>
        /// <param name="tipoTransaccion">Tipo de transaccion</param>
        /// <param name="productoId">Identificacion del producto</param>
        /// <param name="cantidad">Cantidad</param>
        /// <param name="precioUnitario">Precio unitario</param>
        /// <param name="detalle">Detalle</param>
        public async Task RegistraTransaccionAsync(string tipoTransaccion, Guid productoId, int cantidad, decimal precioUnitario, string? detalle)
        {
            var producto = await productoRepository.ObtenerPorIdAsync(productoId);
            if (producto == null) throw new Exception(Constantes.NoExisteProducto);

            if (tipoTransaccion == Constantes.TipoVenta && producto.StockCantidad < cantidad)
                throw new Exception(Constantes.StockInsuficiente);

            var transaccion = new TransaccionModelo(tipoTransaccion, productoId, cantidad, precioUnitario, detalle);

            int nuevoStock = tipoTransaccion == Constantes.TipoCompra ? producto.StockCantidad + cantidad : producto.StockCantidad - cantidad;
            await transaccionRepository.RegistrarTransaccionAsync(transaccion);
            await productoRepository.ActualizarStockAsync(productoId, nuevoStock);
        }

        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        /// <returns>Lista de productos</returns>
        public async Task<IEnumerable<TransaccionModelo>> ObtenerMovimientosAsync()
        {
            return await transaccionRepository.ObtenerTodosAsync();
        }

    }
}
