using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlasticSYS.Models
{
    [Table("clientes")]
    public class Cliente
    {
        [Key]
        [Column("ClienteID")]
        public int ClienteId { get; set; }
        [Column("Nombre")]
        public string Nombre { get; set; }
        [Column("Email")]
        public string Correo { get; set; }
        [Column("Telefono")]
        public string Telefono { get; set; }
        public List<Venta> Ventas { get; set; } = new List<Venta>();
    }
}
