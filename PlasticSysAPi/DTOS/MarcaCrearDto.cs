using System.ComponentModel.DataAnnotations;

// Cambia el namespace para que coincida con el nombre de tu proyecto.
namespace PlasticSysAPI.DTOS
{
    public class MarcaCrearDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        public string Nombre { get; set; }
    }
}