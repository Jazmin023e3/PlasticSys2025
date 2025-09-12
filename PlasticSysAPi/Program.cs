using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios de controladores
builder.Services.AddControllers();

// Agregar Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer(); // Para generar documentación automáticamente
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Mi API",
        Version = "v1",
        Description = "API de ejemplo funcionando con Swagger 3.x"
    });
});

var app = builder.Build();

// Configurar Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Genera swagger.json
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
