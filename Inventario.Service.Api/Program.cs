using Microsoft.OpenApi.Models;
using Inventario.Service.Infraestructura;
using Inventario.Service.Infraestructura.Contextos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    { Title = "Api Caduca REST", Version = "v1" });
});

builder.Services.AddDbContext<InventarioContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaConexion")));

builder.Services.AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
