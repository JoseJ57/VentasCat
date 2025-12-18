using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentasSD.Models
{
    public class Tipo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipo { get; set; }

        [Required]
        public string? Nombre { get; set; }

        public ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();
        public ICollection<TallaTipo> TallaTipos { get; set; } = new List<TallaTipo>();
        public ICollection<TipoMaterial> TipoMateriales { get; set; } = new List<TipoMaterial>();

    }
}
