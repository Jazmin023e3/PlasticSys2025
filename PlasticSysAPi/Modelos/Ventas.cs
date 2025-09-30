using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlasticSYS.Models
{
    [Table("ventas")]
    public class Venta
    {
        [Key]
        [Column("VentaId")]
        public int VentaId { get; set; }
        [Column("FechaVenta")]
        public DateTime Fecha { get; set; }
        [Column("Total")]

        public decimal Total { get; set; }
        [Column("ClienteId")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
    }
}