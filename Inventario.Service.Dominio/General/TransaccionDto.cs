namespace Inventario.Service.Dominio.General
{
    /// <summary>
    /// Clase para los datos de transaccion
    /// </summary>
    public class TransaccionDto
    {
        public string? TipoTransaccion { get; set; }
        public Guid ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string? Detalle { get; set; }
    }
}
