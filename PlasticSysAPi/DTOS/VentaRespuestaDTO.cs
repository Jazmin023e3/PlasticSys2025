using PlasticSYS.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlasticSysAPi.DTOS
{
    public class VentaRespuestaDTO
    {
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
      
        public decimal Total { get; set; }
      
        public int ClienteId { get; set; }
    }
}
