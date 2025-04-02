using FluentValidation;
using Inventario.Service.Dominio.Modelos.Producto;

namespace Inventario.Service.Dominio.General
{
    /// <summary>
    /// Clase con validaciones generales para producto
    /// </summary>
    public class ProductoValidator : AbstractValidator<ProductoModelo>
    {
        public ProductoValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre del producto es obligatorio.")
                                  .Length(1, 100).WithMessage("El nombre debe tener entre 1 y 100 caracteres.");
            RuleFor(x => x.Precio).GreaterThan(0).WithMessage("El precio debe ser mayor que 0.");
            RuleFor(x => x.StockCantidad).GreaterThan(0).WithMessage("El stock debe ser mayor que 0.");
        }
    }
}
