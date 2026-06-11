using Inventario.Service.Dominio.General;
using Inventario.Service.Dominio.Interfaces.Productos;
using Inventario.Service.Dominio.Modelos.Transaccion;

namespace Inventario.Service.Aplicacion.Transaccion
{
    /// <summary>
    /// Clase con la logica de negocio para la transaccion
    /// </summary>
    public class RegistrarTransaccionUseCases : IRegistrarTransaccionUseCases
    {
        /// <summary>
        /// Instancia para interfaz del repositorio de transacciones
        /// </summary>
        private readonly ITransaccionRepository transaccionRepository;

        /// <summary>
        /// Instancia para interfaz del repositorio de productos
        /// </summary>
        private readonly IProductoRepository productoRepository;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public RegistrarTransaccionUseCases(ITransaccionRepository transaccionRepository, IProductoRepository productoRepository)
        {
            this.transaccionRepository = transaccionRepository;
            this.productoRepository = productoRepository;
        }

        /// <summary>
        /// Registra una transaccion de compra o venta
        /// </summary>
        public async Task RegistraTransaccionAsync(string tipoTransaccion, Guid productoId, int cantidad, decimal precioUnitario, string? detalle)
        {
            var producto = await productoRepository.ObtenerPorIdAsync(productoId);
            if (producto == null) throw new Exception(Constantes.NoExisteProducto);

            if (tipoTransaccion == Constantes.TipoVenta && producto.StockCantidad < cantidad)
                throw new Exception(Constantes.StockInsuficiente);

            var transaccion = new TransaccionModelo(tipoTransaccion, productoId, cantidad, precioUnitario, detalle);

            int nuevoStock = tipoTransaccion == Constantes.TipoCompra
                ? producto.StockCantidad + cantidad
                : producto.StockCantidad - cantidad;

            await transaccionRepository.RegistrarTransaccionAsync(transaccion);
            await productoRepository.ActualizarStockAsync(productoId, nuevoStock);
        }

        /// <summary>
        /// Obtiene todos los movimientos registrados
        /// </summary>
        public async Task<IEnumerable<TransaccionModelo>> ObtenerMovimientosAsync()
        {
            return await transaccionRepository.ObtenerTodosAsync();
        }
    }
}
