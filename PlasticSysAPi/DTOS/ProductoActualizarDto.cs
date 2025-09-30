using System.ComponentModel.DataAnnotations;

namespace PlasticSysAPI.DTOS
{
    public class ProductoActualizarDto
    {
        [Required(ErrorMessage = "El ID del producto es obligatorio.")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }

        [MaxLength(200, ErrorMessage = "La descripción no puede exceder los 200 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "La marca es obligatoria.")]
        public int MarcaId { get; set; }
    }
}