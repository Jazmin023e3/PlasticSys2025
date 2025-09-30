using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlasticSYS.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        // ... otras propiedades

        // CORREGIDO: Cambiamos a string para usar BCrypt de forma estándar
        public string PasswordHash { get; set; }
        public string Rol { get; set; }
        public string Username { get; internal set; }
        public string Nombre { get; internal set; }
        public string Correo { get; internal set; }
        public object UsuarioId { get; internal set; }
    }
}
