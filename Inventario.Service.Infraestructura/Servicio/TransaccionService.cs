using Inventario.Service.Dominio.Interfaces.Productos;
using Inventario.Service.Dominio.Modelos.Transaccion;
using Inventario.Service.Infraestructura.Contextos;
using Inventario.Service.Infraestructura.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Service.Infraestructura.Servicio
{
    public class TransaccionService : ITransaccionRepository
    {
        /// <summary>
        /// Objeto de inventario
        /// </summary>
        private readonly InventarioContexto inventarioContexto;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="inventarioContexto">Inyeccion del objeto de inventario</param>
        public TransaccionService(InventarioContexto inventarioContexto)
        {
            this.inventarioContexto = inventarioContexto;
        }

        /// <summary>
        /// Registra la transaccion en la base de datos
        /// </summary>
        public async Task<bool> RegistrarTransaccionAsync(TransaccionModelo transaccion)
        {
            var entidad = MapearAEntidad(transaccion);
            inventarioContexto.Transacciones.Add(entidad);
            await inventarioContexto.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Obtiene todos los movimientos
        /// </summary>
        public async Task<List<TransaccionModelo>> ObtenerTodosAsync()
        {
            var entidades = await inventarioContexto.Transacciones.ToListAsync();
            return entidades.Select(MapearAModelo).ToList();
        }

        private static TransaccionModelo MapearAModelo(TransaccionEntidad e) =>
            new(e.TipoTransaccion, e.ProductoId, e.Cantidad, e.PrecioUnitario, e.Detalle);

        private static TransaccionEntidad MapearAEntidad(TransaccionModelo m) =>
            new()
            {
                TransaccionId = m.TransaccionId,
                Fecha = m.Fecha,
                TipoTransaccion = m.TipoTransaccion,
                ProductoId = m.ProductoId,
                Cantidad = m.Cantidad,
                PrecioUnitario = m.PrecioUnitario,
                PrecioTotal = m.PrecioTotal,
                Detalle = m.Detalle
            };
    }
}
