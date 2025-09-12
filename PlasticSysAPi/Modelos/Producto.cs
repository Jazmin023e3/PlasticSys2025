using System.Text.RegularExpressions;

namespace PlasticSYS.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
    }
}