using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentasSD.Models
{
    public class TallaArticulo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTallalArticulo { get; set; }

        [Required]
        public int IdArticulo { get; set; }
        [ForeignKey("IdArticulo")]
        public Articulo? Articulo { get; set; }

        [Required]
        public int IdTalla { get; set; }
        [ForeignKey("IdTalla")]
        public Talla? Talla { get; set; }

    }
}
