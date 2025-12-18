using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.RegularExpressions;
namespace VentasSD.Models
{
    public class Credito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCredito { get; set; }
        [Required]
        public DateOnly Fecha { get; set; }
        [Required]
        public Decimal Monto { get; set; }
        public string? Observacion { get; set; }
        [Required]
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public Cliente? Cliente { get; set; }

        public ICollection<Orden> Ordenes { get; set; }=new List<Orden>();
        public ICollection<TipoPago> TipoPagos { get; set; }=new List<TipoPago>();

    }
}
