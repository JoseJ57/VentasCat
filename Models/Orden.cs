using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VentasSD.Dto;

namespace VentasSD.Models
{
    public class Orden
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOrden { get; set; }

        [Required]
        public DateOnly? Fecha { get; set; }

        [Required]
        public MetodoPagos Pago { get; set; }

        [Required]
        public Decimal Total { get; set; }
        [Required]
        public Estados Estado { get; set; }
        [Required]
        public bool ConEnvio { get; set; }
        // Relaciones
        public ICollection<DetalleOrden> DetalleOrdenes { get; set; } = new List<DetalleOrden>();
        public ICollection<TipoPago> TipoPagos{ get; set; } = new List<TipoPago>();

        [Required]
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }


        public int IdCredito { get; set; }
        [ForeignKey("IdCredito")]
        public Credito? Credito { get; set; }
        
        public int IdEnvio { get; set; }
        [ForeignKey("IdEnvio")]
        public Envio? Envio { get; set; }
    }
}
