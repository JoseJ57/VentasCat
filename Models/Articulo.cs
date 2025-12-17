using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using VentasSD.Dto;

namespace VentasSD.Models
{
    public class Articulo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdArticulo { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(30, ErrorMessage = "El nombre no puede tener más de 30 caracteres.")]
        public string? Nombre { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "La descripcion no puede tener más de 100 caracteres.")]
        public string? Descripcion { get; set; }
        [Required]
        public Decimal Precio { get; set; }

        [Required]
        public EstadoArticulos Estado { get; set; }


        [Required(ErrorMessage = "El celular es obligatorio.")]
        [Phone(ErrorMessage = "Número de celular inválido.")]
        public string? Celular { get; set; }

        [EmailAddress(ErrorMessage = "El correo no es válido.")]
        public string? Correo { get; set; }
        [Required]
        public string? Dirección { get; set; }
        [Required]
        public bool Frecuente { get; set; } = true;

        // Relaciones
        public ICollection<TallaArticulo> TallaArticulos { get; set; } = new List<TallaArticulo>();
        public ICollection<MaterialArticulo> MaterialArticulos { get; set; } = new List<MaterialArticulo>();

        [Required]
        public int IdMarca { get; set; }
        [ForeignKey("IdMarca")]
        public Marca? Marca { get; set; }

        //[Required]
        //public int IdTipo{ get; set; }
        //[ForeignKey("IdTipo")]
        //public Tipo? Tipo{ get; set; }

    }
}
