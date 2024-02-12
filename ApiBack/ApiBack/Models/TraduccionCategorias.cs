using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBack.Models
{
    public class TraduccionCategorias
    {
        [Key]
        public int IdTraduccionCategoria { get; set; }

 
        public int? IdCategoria { get; set; }

        public int? IdiomaId { get; set; } // Cambiado para aclarar que es una FK y seguir convenciones de nombrado.

        [Required(ErrorMessage = "El nombre de la traducción es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }

        // Aquí, uso virtual para permitir la carga diferida y no uso [Required] para permitir que sean opcionales.
        [ForeignKey("IdCategoria")]
        public virtual Categorias Categoria { get; set; }

        [ForeignKey("IdiomaId")]
        public virtual Idioma IdiomaNavigation { get; set; }
    }
}
