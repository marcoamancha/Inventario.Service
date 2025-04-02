namespace Inventario.Service.Dominio.General
{
    /// <summary>
    /// Constantes generales
    /// </summary>
    public class Constantes
    {
        //Tipos de transaccion
        public const string TipoVenta = "venta";
        public const string TipoCompra = "compra";

        //Mensajes de error
        public const string NoExisteProducto = "El producto no existe.";
        public const string StockInsuficiente = "Stock insuficiente para la venta.";
    }
}
