using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace PlasticSYS.Services // Asegúrate de que este namespace sea correcto
{
    /// <summary>
    /// Servicio responsable de generar JSON Web Tokens (JWT).
    /// Requiere la configuración 'JwtSettings' en appsettings.json.
    /// </summary>
    public class JwtService
    {
        private readonly IConfiguration _configuration;
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
            // Lectura de la configuración de appsettings.json
            _secretKey = _configuration["JwtSettings:SecretKey"] ?? throw new ArgumentNullException("JwtSettings:SecretKey not configured");
            _issuer = _configuration["JwtSettings:Issuer"] ?? "PlasticSysAPI";
            _audience = _configuration["JwtSettings:Audience"] ?? "PlasticSysWebApp";
        }

        public string GenerateToken(int userId, string username, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // La clave secreta debe ser leída como bytes para la firma
            var key = Encoding.ASCII.GetBytes(_secretKey);

            // 1. Definición de claims (información que va en el token)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role) // Incluye el rol del usuario (Ej: Operador)
            };

            // 2. Creación de la descripción del token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7), // El token expira en 7 días
                Issuer = _issuer,
                Audience = _audience,
                // Uso de la clave secreta para firmar (cifrar) el token
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // 3. Creación y serialización del token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        internal string GenerateToken(object usuarioId, string username, string rol)
        {
            throw new NotImplementedException();
        }
    }
}