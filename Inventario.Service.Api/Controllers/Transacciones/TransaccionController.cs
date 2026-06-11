using Inventario.Service.Dominio.General;
using Inventario.Service.Dominio.Interfaces.Productos;
using Inventario.Service.Dominio.Modelos.Transaccion;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Service.Api.Controllers.Transacciones
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionController : ControllerBase
    {
        /// <summary>
        /// Puerto de entrada del caso de uso de transacciones
        /// </summary>
        private readonly IRegistrarTransaccionUseCases registrarTransaccionUseCases;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="registrarTransaccionUseCases">Inyeccion del caso de uso de transaccion</param>
        public TransaccionController(IRegistrarTransaccionUseCases registrarTransaccionUseCases)
        {
            this.registrarTransaccionUseCases = registrarTransaccionUseCases;
        }

        /// <summary>
        /// Api para obtener todos los productos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ObtenerMovimientos()
        {
            try
            {
                IEnumerable<TransaccionModelo> movimientos = await registrarTransaccionUseCases.ObtenerMovimientosAsync();
                return Ok(new InventarioRespuesta<IEnumerable<TransaccionModelo>>(movimientos));
            }
            catch (Exception ex)
            {
                return BadRequest(new InventarioRespuesta<Exception>(ex, false, ex.Message));
            }
        }

        /// <summary>
        /// Api para registrar una transaccion
        /// </summary>
        /// <param name="request">Datos para el registro de la transaccion</param>
        [HttpPost]
        public async Task<IActionResult> RegistrarTransaccion([FromBody] TransaccionDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await registrarTransaccionUseCases.RegistraTransaccionAsync(request.TipoTransaccion, request.ProductoId, request.Cantidad, request.PrecioUnitario, request.Detalle);
                return Ok(new InventarioRespuesta<Guid>(request.ProductoId, true, "Transacción registrada correctamente."));
            }
            catch (Exception ex)
            {
                return BadRequest(new InventarioRespuesta<Exception>(ex, false, ex.Message));
            }
        }
    }
}
