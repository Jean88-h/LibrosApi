using MediatR;
using Microsoft.EntityFrameworkCore;
using Uttt.Micro.Libro.Aplicacion;
using Uttt.Micro.Libro.Extensiones;
using Uttt.Micro.Libro.Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Configurar el puerto (necesario para Railway)
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

// Agregar servicios personalizados (incluye DbContext, controladores, FluentValidation, MediatR, AutoMapper)
builder.Services.AddCustomServices(builder.Configuration);

// Configurar Swagger y OpenAPI
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Nuevo.Manejador).Assembly);

// Configurar CORS para React (sin slash final en la URL)
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirReact", policy =>
    {
        policy.WithOrigins(
                "http://localhost:3000",
                "https://api-libro-58bh9kx9v-val88s-projects-3e12ef5a.vercel.app"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("PermitirReact");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
