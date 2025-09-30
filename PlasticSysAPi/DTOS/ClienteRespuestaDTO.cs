using System.ComponentModel.DataAnnotations.Schema;

namespace PlasticSysAPi.DTOS
{
    public class ClienteRespuestaDTO
    {
        public int ClienteId { get; set; }
      
        public string Nombre { get; set; }
      
        public string Correo { get; set; }
       
        public string Telefono { get; set; }
    }
}
