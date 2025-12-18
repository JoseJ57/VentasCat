using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentasSD.Models
{
    public class DetalleOrden
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetalleOrden { get; set; }


        [Required]
        public int Cantidad { get; set; }
        [Required]
        public Decimal Subtotal{ get; set; }
        [Required]
        public string? Observacion { get; set; }
        [Required]
        public decimal Descuento { get; set; }

        public ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
        

        [Required]
        public int IdOrden { get; set; }
        [ForeignKey("IdOrden")]
        public Orden? Orden{ get; set; }
        
        [Required]
        public int IdArticulo { get; set; }
        [ForeignKey("IdArticulo")]
        public Articulo? Articulo{ get; set; }

    }
}
