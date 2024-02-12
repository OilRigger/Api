using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiBack.Models
{
    public class TraduccionProductos
   
        {
            [Key]
            public int IdTraduccionProduct { get; set; }

            // Indica que IdProducto es una clave foránea con el atributo ForeignKey,
            // y opcionalmente especifica el nombre de la propiedad de navegación.
            public int? IdProducto { get; set; }

            // Cambiado a IdiomaId para claridad, indica que es una FK hacia Idioma.
            public int? IdiomaId { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(100, ErrorMessage = "La longitud máxima del nombre es de 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción del producto es obligatoria.")]
        [StringLength(500, ErrorMessage = "La longitud máxima de la descripción es de 500 caracteres.")]
        public string Descripcion { get; set; }

        // Usa virtual para permitir la carga diferida de Entity Framework,
        // y el atributo [ForeignKey] si es necesario especificar la FK explícitamente.
        [ForeignKey("IdProducto")]
            public virtual Productos Producto { get; set; } // Considera cambiar a singular si es posible.

            // Asegúrate de que la propiedad de navegación a Idioma esté correctamente configurada.
            [ForeignKey("IdiomaId")]
            public virtual Idioma IdiomaNavigation { get; set; }
        }
    }

