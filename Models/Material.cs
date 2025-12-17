using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentasSD.Models
{
    public class Material
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMaterial { get; set; }

        [Required]
        public string? Nombre { get; set; }

        public ICollection<MaterialArticulo> MaterialArticulos { get; set; } = new List<MaterialArticulo>();
        public ICollection<TipoMaterial> TipoMaterials { get; set; } = new List<TipoMaterial>();
    }
}
