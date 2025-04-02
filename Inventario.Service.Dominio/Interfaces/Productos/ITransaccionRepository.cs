using Inventario.Service.Dominio.General;
using Inventario.Service.Dominio.Modelos.Transaccion;

namespace Inventario.Service.Dominio.Interfaces.Productos
{
    public interface ITransaccionRepository
    {
        /// <summary>
        /// Obtiene todos los movimientos
        /// </summary>
        /// <returns>Lista de productos</returns>
        Task<List<TransaccionModelo>> ObtenerTodosAsync();

        /// <summary>
        /// Registra la transaccion
        /// </summary>
        /// <param name="transaccion">Datos para la transaccion</param>
        Task<bool> RegistrarTransaccionAsync(TransaccionModelo transaccion);
    }
}
