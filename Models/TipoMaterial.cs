using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentasSD.Models
{
    public class TipoMaterial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoMaterial { get; set; }

        [Required]
        public int IdMaterial { get; set; }
        [ForeignKey("IdMaterial")]
        public Material? Material { get; set; }

        //[Required]
        //public int IdTipo{ get; set; }
        //[ForeignKey("IdTipo")]
        //public Tipo? Tipo { get; set; }


    }
}
