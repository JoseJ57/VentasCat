using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentasSD.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(30, ErrorMessage = "El nombre no puede tener más de 30 caracteres.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s'-]+$", ErrorMessage = "El nombre solo puede contener letras y espacios.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El apellido del es obligatorio.")]
        [StringLength(30, ErrorMessage = "El apellido del no puede tener más de 30 caracteres.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s'-]+$", ErrorMessage = "El apellido del solo puede contener letras y espacios.")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "El carnet es obligatorio.")]
        [StringLength(10, ErrorMessage = "El carnet no puede tener más de 10 caracteres.")]
        public string? Carnet { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateOnly? FechaNacimiento { get; set; }
        [Required]
        public int Nit { get; set; }

        [Required]
        public bool Frecuente {  get; set; }
        [Required]
        [RegularExpression(@"^[0-9\s]+$")]
        [StringLength(8, ErrorMessage = "no puede tener más de 8 caracteres.")]
        public string? Celular { get; set; }


        public ICollection<Orden> Ordenes { get; set; } = new List<Orden>();
        public ICollection<Credito> Creditos{ get; set; } = new List<Credito>();
        public ICollection<Usuario> Usuarios{ get; set; } = new List<Usuario>();

        

    }
}
