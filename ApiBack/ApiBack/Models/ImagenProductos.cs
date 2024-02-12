using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBack.Models
{
    public class ImagenProductos
    {
        public int Id { get; set; }

        [Required] // Indica que la clave foránea no puede ser null
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "La URL de la imagen es obligatoria.")]
        [Url(ErrorMessage = "La URL de la imagen debe ser una URL válida.")]
        public string ImagenUrl { get; set; }

        public int? Orden { get; set; } // Puede ser null si el orden no es obligatorio

        [ForeignKey("ProductoId")]
        public virtual Productos Producto { get; set; } // Propiedad de navegación
    }
}