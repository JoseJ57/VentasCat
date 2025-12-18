using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentasSD.Models
{
    public class TipoPago
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoPago { get; set; }
        [Required]
        public DateTime Fecha { get;set; }
        [Required]
        public byte[] Comprobante { get; set; }
        public string? Codigo { get; set; }

        [Required]
        public bool Estado {  get; set; }

        

        [Required]
        public int IdOrden { get; set; }
        [ForeignKey("IdOrden")]
        public Orden? Orden { get; set; }

        public int IdCredito { get; set; }
        [ForeignKey("IdCredito")]
        public Credito? Credito { get; set; }

    }
}
