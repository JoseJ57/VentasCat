using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentasSD.Models
{
    public class Talla
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTalla { get; set; }

        [Required]
        public string? Nombre { get; set; }

        public ICollection<TallaArticulo> TallaArtculos { get; set; } = new List<TallaArticulo>();
        public ICollection<TallaTipo> TallaTipos { get; set; } = new List<TallaTipo>();


    }
}
