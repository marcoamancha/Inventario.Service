using System.ComponentModel.DataAnnotations;

namespace Inventario.Service.Infraestructura.Entidades
{
    /// <summary>
    /// Entidad de persistencia para transacciones (EF Core)
    /// </summary>
    public class TransaccionEntidad
    {
        [Key]
        public Guid TransaccionId { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoTransaccion { get; set; } = string.Empty;
        public Guid ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioTotal { get; set; }
        public string? Detalle { get; set; }
    }
}
