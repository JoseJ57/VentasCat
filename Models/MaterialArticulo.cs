using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentasSD.Models
{
    public class MaterialArticulo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMaterialArticulo { get; set; }

        [Required]
        public int IdArticulo { get; set; }
        [ForeignKey("IdArticulo")]
        public Articulo? Articulo { get; set; }

        [Required]
        public int IdMaterial { get; set; }
        [ForeignKey("IdMaterial")]
        public Material? Material { get; set; }

    }
}
