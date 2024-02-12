using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBack.Models
{
    public class DetallesPedidos
    {
        public int Id { get; set; }

        [Required]
        public int PedidoId { get; set; } // Clave foránea, marcada como requerida con el atributo [Required]

        [Required]
        public int ProductoId { get; set; } // Clave foránea, marcada como requerida con el atributo [Required]

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1")]
        public int Cantidad { get; set; } // Validación para asegurar un valor mínimo de 1

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PrecioUnitario { get; set; } // Uso de [Column] para especificar la precisión y escala

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, 1, ErrorMessage = "El descuento debe estar entre 0 y 1")]
        public decimal Descuento { get; set; } // Validación para asegurar que el descuento esté en un rango válido

        // Propiedades de navegación
        [ForeignKey("PedidoId")]
        public virtual Pedidos Pedido { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Productos Producto { get; set; }
    }
}
