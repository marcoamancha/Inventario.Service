using Inventario.Service.Dominio.General;
using Inventario.Service.Dominio.Modelos.Transaccion;

namespace Inventario.Service.Dominio.Interfaces.Productos
{
    /// <summary>
    /// Puerto de entrada para casos de uso de transacciones
    /// </summary>
    public interface IRegistrarTransaccionUseCases
    {
        /// <summary>
        /// Registra una transaccion de compra o venta
        /// </summary>
        Task RegistraTransaccionAsync(string tipoTransaccion, Guid productoId, int cantidad, decimal precioUnitario, string? detalle);

        /// <summary>
        /// Obtiene todos los movimientos registrados
        /// </summary>
        Task<IEnumerable<TransaccionModelo>> ObtenerMovimientosAsync();
    }
}
