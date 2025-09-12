using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore; // Agrega esta directiva
using PlasticSysAPI.DTOS; // Aseg�rate que tu namespace DTO est� aqu�
using PlasticSYS.Models; // Aseg�rate que tu namespace Models est� aqu�

var builder = WebApplication.CreateBuilder(args);

// Agrega la configuraci�n de la base de datos como un servicio
builder.Services.AddDbContext<PlasticSysContext>(options =>
{
    // Usa la cadena de conexi�n del archivo appsettings.json
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Agrega los servicios de autorizaci�n si los necesitas
builder.Services.AddAuthorization();

// Agrega servicios de controladores
builder.Services.AddControllers();

// Agrega Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "PlasticSys2025",
        Version = "v1",
        Description = "Web Api"
    });
});

var app = builder.Build();

// Configura el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlasticSys2025");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
