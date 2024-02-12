using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBack.Models
{
    public class Pedidos
    {
        public int Id { get; set; }

        public int? ClienteId { get; set; } // Asumiendo que un pedido puede o no tener un cliente asociado.

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime? FechaEnvio { get; set; }

        [Required(ErrorMessage = "El estado del pedido es obligatorio.")]
        public string Estado { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Usuario Cliente { get; set; } // La propiedad de navegación para el cliente.

        // Propiedad de navegación para la relación uno a muchos con DetallePedido
        public virtual ICollection<DetallesPedidos> DetallesPedidos { get; set; } = new HashSet<DetallesPedidos>();
    }
}