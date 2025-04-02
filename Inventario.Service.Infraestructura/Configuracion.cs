using Inventario.Service.Aplicacion.Productos;
using Inventario.Service.Aplicacion.Transacion;
using Inventario.Service.Dominio.Interfaces.Productos;
using Inventario.Service.Infraestructura.Servicio;
using Microsoft.Extensions.DependencyInjection;

namespace Inventario.Service.Infraestructura
{
    public static class Configuracion
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IProductoRepository, ProductoService>();
            services.AddScoped<ITransaccionRepository, TransaccionService>();
            services.AddScoped<ProductoUseCases>();
            services.AddScoped<RegistrarTransaccionUseCases>();
            return services;
        }
    }
}
