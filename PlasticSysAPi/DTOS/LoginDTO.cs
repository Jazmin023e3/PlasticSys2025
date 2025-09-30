using System.ComponentModel.DataAnnotations;

namespace PlasticSYS.DTOS
{
    public class RegistroDto
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
