using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBack.Models
{
    public class Productos
    {
        public int Id { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
        public decimal Precio { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad en stock no puede ser negativa.")]
        public int CantidadStock { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual Categorias Categoria { get; set; }

        // Propiedad de navegación para la relación uno a muchos con DetallePedido
        public virtual ICollection<DetallesPedidos> DetallesPedidos { get; set; } = new HashSet<DetallesPedidos>();
    }
}