using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using PlasticSYS.Models;
using PlasticSYS.Services; // Necesario para PasswordService y JwtService
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using Microsoft.OpenApi.Models; // Necesario para la configuraci�n de Swagger JWT

var builder = WebApplication.CreateBuilder(args);

// ===============================================
// 1. CONFIGURACI�N DE BASE DE DATOS
// ===============================================
builder.Services.AddDbContext<PlasticSysContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    var serverVersion = ServerVersion.AutoDetect(connectionString);
    options.UseMySql(connectionString, serverVersion);
});
// ===============================================
// 2. REGISTRO DE SERVICIOS DE NEGOCIO (INYECCI�N DE DEPENDENCIAS)
// ===============================================
// Servicio para cifrar contrase�as (necesario para AuthController)
builder.Services.AddScoped<PasswordService>();
// Servicio para generar tokens JWT (necesario para AuthController)
builder.Services.AddScoped<JwtService>();

// ===============================================
// 3. CONFIGURACI�N DE AUTENTICACI�N JWT
// ===============================================
// Clave secreta desde appsettings.json
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"] ?? throw new ArgumentNullException("JwtSettings:SecretKey not configured"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false; // Solo para desarrollo, en producci�n debe ser true
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ClockSkew = TimeSpan.Zero // No hay tolerancia de tiempo de expiraci�n
        };
    });
// ===============================================
// 4. CONFIGURACI�N DE CORS (PERMITIR COMUNICACI�N CON EL FRONTEND)
// ===============================================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            // En desarrollo, permite cualquier origen
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});// ===============================================
// 5. CONFIGURACI�N DE SWAGGER (PARA ENVIAR TOKENS)
// ===============================================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
c.SwaggerDoc("v1", new OpenApiInfo { Title = "PlasticSys API", Version = "v1" });

// Configuraci�n para que Swagger pueda enviar Tokens JWT en las peticiones
c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
{
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "Ingresa tu Token JWT de esta manera: Bearer {token}"
});
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
var app = builder.Build();

// ===============================================
// 6. MIDDLEWARES (EL ORDEN ES CR�TICO)
// ===============================================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

// Habilitar CORS para que el frontend pueda hablar con la API
app.UseCors("AllowFrontend");

// Seguridad - EL ORDEN ES CR�TICO:
app.UseAuthentication(); // �Qui�n eres? (Lee el Token JWT)
app.UseAuthorization();  // �Qu� puedes hacer? (Verifica los Roles)

app.MapControllers();

app.Run();
