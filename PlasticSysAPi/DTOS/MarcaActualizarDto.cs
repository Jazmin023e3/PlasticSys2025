// Archivo: /DTOs/MarcaActualizarDto.cs
using System.ComponentModel.DataAnnotations;

namespace PlasticSysAPI.DTOS
{
    public class MarcaActualizarDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        public string Nombre { get; set; }
    }
}