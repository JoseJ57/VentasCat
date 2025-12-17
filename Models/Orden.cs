using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VentasSD.Dto;

namespace VentasSD.Models
{
    public class Orden
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateOnly? Fecha { get; set; }

        [Required]
        public MetodoPagos Pago { get; set; }

        [Required]
        public Decimal Total { get; set; }
        [Required]
        public Estados Estado { get; set; }
        [Required]
        public bool Envio { get; set; }
        // Relaciones
        //public ICollection<DetalleOrden> DetalleOrdenes { get; set; } = new List<DetalleOrden>();
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public Cliente? Cliente { get; set; }

        //[Required]
        //public int IdEmpleado { get; set; }
        //[ForeignKey("IdEmpleado")]
        //public Empleado? Empleado { get; set; }

    }
}
