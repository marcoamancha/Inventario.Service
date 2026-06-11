using Inventario.Service.Aplicacion.Productos;
using Inventario.Service.Aplicacion.Transaccion;
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
            services.AddScoped<IProductoUseCases, ProductoUseCases>();
            services.AddScoped<IRegistrarTransaccionUseCases, RegistrarTransaccionUseCases>();
            return services;
        }
    }
}
