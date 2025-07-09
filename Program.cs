using MediatR;
using Microsoft.EntityFrameworkCore;
using Uttt.Micro.Libro.Aplicacion;
using Uttt.Micro.Libro.Extensiones;
using Uttt.Micro.Libro.Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios personalizados (incluye DbContext, controladores, FluentValidation, MediatR, AutoMapper)
builder.Services.AddCustomServices(builder.Configuration);

// Configurar Swagger y OpenAPI
builder.Services.AddSwaggerGen(); // Swashbuckle
builder.Services.AddMediatR(typeof(Nuevo.Manejador).Assembly);

// Configurar CORS para React
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirReact", policy =>
    {
        policy.WithOrigins(
                "http://localhost:3000",
                "https://api-libro-lgojqdihs-val88s-projects-3e12ef5a.vercel.app/"  // <-- Reemplaza con la URL de tu frontend desplegado en Vercel
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Usar CORS
app.UseCors("PermitirReact");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
