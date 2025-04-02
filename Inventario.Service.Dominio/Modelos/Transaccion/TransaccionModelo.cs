namespace Inventario.Service.Dominio.Modelos.Transaccion
{
    public class TransaccionModelo
    {
        public Guid TransaccionId { get; private set; } = Guid.NewGuid();
        public DateTime Fecha { get; private set; } = DateTime.UtcNow;
        public string TipoTransaccion { get; private set; } // "compra" o "venta"
        public Guid ProductoId { get; private set; }
        public int Cantidad { get; private set; }
        public decimal PrecioUnitario { get; private set; }
        public decimal PrecioTotal => Cantidad * PrecioUnitario;
        public string? Detalle { get; private set; }

        public TransaccionModelo(string tipoTransaccion, Guid productoId, int cantidad, decimal precioUnitario, string? detalle)
        {
            if (cantidad <= 0) throw new ArgumentException("La cantidad debe ser mayor a 0.");
            if (precioUnitario <= 0) throw new ArgumentException("El precio unitario debe ser mayor a 0.");
            if (tipoTransaccion != "compra" && tipoTransaccion != "venta")
                throw new ArgumentException("Tipo de transacción no válido.");

            TipoTransaccion = tipoTransaccion;
            ProductoId = productoId;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            Detalle = detalle;
        }
    }
}
