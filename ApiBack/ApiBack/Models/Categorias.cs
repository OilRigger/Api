using System.ComponentModel.DataAnnotations;

namespace ApiBack.Models
{
    public class Categorias // Cambiado a singular para seguir las convenciones de nomenclatura
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre de la categoría no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }
    }
}