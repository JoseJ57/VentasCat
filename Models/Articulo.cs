using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
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
        [StringLength(100, ErrorMessage = "La descripcion no puede tener más de 100 caracteres.")]
        public string? Descripcion { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "La recomendacion no puede tener más de 100 caracteres.")]
        public string? Recomendaciones { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "No puede tener más de 50 caracteres.")]
        public string? Eslogan { get; set; }
        [Required]
        public Decimal Precio { get; set; }

        [Required]
        public EstadoArticulos Estado { get; set; }

        [Required]
        public string Imagen {  get; set; }
        [Required]
        public Categorias Categoria { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "El tipo no puede tener más de 20 caracteres.")]
        public string? TipoArticulo { get; set; }

        // Relaciones

        public ICollection<TallaArticulo> TallaArticulos { get; set; } = new List<TallaArticulo>();
        public ICollection<MaterialArticulo> MaterialArticulos { get; set; } = new List<MaterialArticulo>();
        public ICollection<DetalleOrden> DetallaOrdenes{ get; set; } = new List<DetalleOrden>();
        public ICollection<Inventario> Inventarios{ get; set; } = new List<Inventario>();

        [Required]
        public int IdMarca { get; set; }
        [ForeignKey("IdMarca")]
        public Marca? Marca { get; set; }

        [Required]
        public int IdTipo { get; set; }
        [ForeignKey("IdTipo")]
        public Tipo? Tipo { get; set; }

        

    }
}
