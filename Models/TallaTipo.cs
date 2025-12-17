using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentasSD.Models
{
    public class TallaTipo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTallaTipo { get; set; }

        [Required]
        public int IdTalla { get; set; }
        [ForeignKey("IdTalla")]
        public Talla? Talla { get; set; }

        //[Required]
        //public int IdTipo { get; set; }
        //[ForeignKey("IdTipo")]
        //public Tipo? Tipo { get; set; }
    }

}
