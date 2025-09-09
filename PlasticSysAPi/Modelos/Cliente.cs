using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlasticSysAPi.Modelos
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El Email es obligatorio")]
        [EmailAddress(ErrorMessage = "El Email no tiene un formato válido")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "El Teléfono es obligatorio")]
        [Phone(ErrorMessage = "El Teléfono no tiene un formato válido")]
        public string Telefono { get; set; } = null!;

        // Relación con ventas
        public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
    }
}
