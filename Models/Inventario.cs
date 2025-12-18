using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VentasSD.Dto;

namespace VentasSD.Models
{
    public class Inventario
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdInventario { get; set; }


        [Required]
        public int Cantidad { get; set; }
        [Required]
        public DateTime FechaUpdate { get; set; }
        [Required]
        public AccionInventario Accion {  get; set; }
        [Required]
        public Decimal PrecioIngreso { get; set; }


        [Required]
        public int IdArticulo { get; set; }
        [ForeignKey("IdArticulo")]
        public Articulo? Articulo { get; set; }

    }
}
