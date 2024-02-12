using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBack.Models
{
    public class Pago
    {
        [Key]
        public int Idpagos { get; set; } // Considera cambiarlo a PagoId para seguir convenciones

        // Considera si realmente puede ser null. Si no, cambiar a 'int'
        public int? Idpedidos { get; set; }

        [Required(ErrorMessage = "El método de pago es obligatorio.")]
        public string Metodopago { get; set; }

        [Required(ErrorMessage = "La fecha del pago es obligatoria.")]
        public DateTime Fecha { get; set; } // Si siempre es requerido, quitar el ?

        [ForeignKey("Idpedidos")]
        public virtual Pedidos Pedido { get; set; } // Asegúrate de que el manejo de pagos sin pedido asociado sea intencional
    }
}