using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VentasSD.Dto;

namespace VentasSD.Models
{
    public class Envio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEnvio { get; set; }
        [Required]
        public string? Direccion {  get; set; }
        [Required]
        public DateOnly FechaEntrega { get; set; }
        [Required]
        public decimal  Costo { get; set; }
        [Required]
        public EstadosEnvio Estado {  get; set; }
        [Required]
        public bool PagoIncluido { get; set; }

        public ICollection<Orden> Ordenes { get; set; } = new List<Orden>();

        [Required]
        public int IdTransporte { get; set; }
        [ForeignKey("IdTransporte")]
        public Transporte? Transporte { get; set; }

    }
}
