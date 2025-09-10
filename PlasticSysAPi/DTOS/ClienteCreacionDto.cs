using System.ComponentModel.DataAnnotations;

namespace PlasticSYS.Models.DTOs;

/// <summary>
/// Data Transfer Object para la creación de un nuevo cliente.
/// Contiene las propiedades necesarias para recibir datos de la API.
/// </summary>
public class ClienteCreacionDto
{
    [Required(ErrorMessage = "El Nombre es obligatorio")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "El Email es obligatorio")]
    [EmailAddress(ErrorMessage = "El formato de email no es válido")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "El teléfono es obligatorio")]
    [Phone(ErrorMessage = "El formato del teléfono no es válido")]
    public string Telefono { get; set; } = null!;
}