
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlasticSysAPi.Modelos;

public class Venta
{
    public int VentaId { get; set; }

    [Required(ErrorMessage = "La fecha de la venta es obligatoria")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "El monto es obligatorio")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
    public decimal Monto { get; set; }

    // Clave foránea
    [Required]
    public int ClienteId { get; set; }

    // Relación con Cliente
    [ForeignKey("ClienteId")]
    public virtual Cliente Cliente { get; set; } = null!;
}
