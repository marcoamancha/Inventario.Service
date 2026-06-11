namespace Inventario.Service.Dominio.General
{
    /// <summary>
    /// DTO para la entrada de datos de producto desde la API
    /// </summary>
    public class ProductoDto
    {
        public Guid? ProductoId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Categoria { get; set; }
        public string? Imagen { get; set; }
        public decimal Precio { get; set; }
        public int StockCantidad { get; set; }
    }
}
