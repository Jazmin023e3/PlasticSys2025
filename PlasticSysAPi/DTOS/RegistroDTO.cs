using System.ComponentModel.DataAnnotations;

namespace PlasticSYS.DTOS // Asegúrate de que este namespace coincida con el de tu proyecto
{
    /// <summary>
    /// Data Transfer Object (DTO) para la creación de nuevos usuarios.
    /// Contiene validaciones básicas para garantizar que los datos sean correctos.
    /// </summary>
    public class RegistroDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Password { get; set; }
    }
}
