using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VentasSD.Dto;

namespace VentasSD.Models
{
    public class Transporte
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTransporte { get; set; }
        [Required]
        public TipoTransportes Tipo { get; set; }


        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(30, ErrorMessage = "El nombre no puede tener más de 30 caracteres.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s'-]+$", ErrorMessage = "El nombre solo puede contener letras y espacios.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(30, ErrorMessage = "El nombre no puede tener más de 30 caracteres.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s'-]+$", ErrorMessage = "El nombre solo puede contener letras y espacios.")]
        public string? Empresa { get; set; }
        [Required]
        [RegularExpression(@"^[0-9\s]+$")]
        [StringLength(8, ErrorMessage = "no puede tener más de 8 caracteres.")]
        public string? Celular { get; set; }

        [Required]

        public ICollection<Envio> Envios{ get; set; } = new List<Envio>();

    }
}
