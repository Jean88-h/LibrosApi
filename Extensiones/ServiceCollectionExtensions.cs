using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using FluentValidation.AspNetCore;
using Uttt.Micro.Libro.Aplicacion;
using Uttt.Micro.Libro.Persistencia;

namespace Uttt.Micro.Libro.Extensiones
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configurar FluentValidation
            services.AddControllers()
                    .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Nuevo>());

            // Configurar DbContext con MySQL y Pomelo 8.0.3 + EF Core 8.0.13
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ContextoLibreria>(options =>
                options.UseMySql(connectionString, ServerVersion.Parse("8.0.33-mysql")));
            // O ServerVersion.AutoDetect(connectionString) si la base está accesible

            // MediatR
            services.AddMediatR(typeof(Nuevo.Manejador).Assembly);

            // AutoMapper
            services.AddAutoMapper(typeof(Consulta.Manejador).Assembly);

            return services;
        }
    }
}