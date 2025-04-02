using Inventario.Service.Dominio.Interfaces.Productos;
using Inventario.Service.Dominio.Modelos.Transaccion;
using Inventario.Service.Infraestructura.Contextos;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Service.Infraestructura.Servicio
{
    public class TransaccionService : ITransaccionRepository
    {
        /// <summary>
        /// Objeto de inventario
        /// </summary>
        private InventarioContexto inventarioContexto;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="inventarioContexto">Inyeccion del objeto de inventario</param>
        public TransaccionService(InventarioContexto inventarioContexto)
        {
            this.inventarioContexto = inventarioContexto;
        }

        /// <summary>
        /// Metodo para registrar la transaccion
        /// </summary>
        /// <param name="transaccion">Datos de la transaccion</param>
        public async Task<bool> RegistrarTransaccionAsync(TransaccionModelo transaccion)
        {
            var producto = await inventarioContexto.Productos.FindAsync(transaccion.ProductoId);
            if (producto == null)
                throw new Exception("El producto no existe.");

            if (transaccion.TipoTransaccion == "venta" && producto.StockCantidad < transaccion.Cantidad)
                throw new Exception("Stock insuficiente para la venta.");

            inventarioContexto.Add(transaccion);

            if (transaccion.TipoTransaccion == "compra")
                producto.StockCantidad += transaccion.Cantidad;
            else
                producto.StockCantidad -= transaccion.Cantidad;

            await inventarioContexto.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Obtiene todos los movimientos
        /// </summary>
        public async Task<List<TransaccionModelo>> ObtenerTodosAsync()
        {
            return await inventarioContexto.Transacciones.ToListAsync();
        }
    }
}
