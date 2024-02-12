using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBack.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Passw { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        [Phone]
        public string Telefono { get; set; }

        // Clave foránea para Idioma
        public int? IdIdioma { get; set; }

        // Clave foránea para Rol
        public int? IdRol { get; set; }

        // Propiedad de navegación para Idioma
        [ForeignKey("IdIdioma")]
        public virtual Idioma Idiomas { get; set; }

        // Propiedad de navegación para Rol
        [ForeignKey("IdRol")]
        public virtual Roles Roles { get; set; }

        public virtual ICollection<Pedidos> Pedidos { get; set; } = new HashSet<Pedidos>();

        public Usuario()
        {
            Pedidos = new HashSet<Pedidos>();
        }
    }
}