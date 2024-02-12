using System.ComponentModel.DataAnnotations;

namespace ApiBack.Models

{
    public class Roles
    {
        [Key]
        public int RolId { get; set; }

        [Required(ErrorMessage = "El tipo de rol es obligatorio.")]
        [StringLength(50, ErrorMessage = "El tipo de rol no puede exceder los 50 caracteres.")]
        public string Tipo { get; set; }
    }
}
