using System.ComponentModel.DataAnnotations;
using VentasSD.Models;

namespace VentasSD.ViewModels
{
    public class TallaViewModel
    {
        public int IdTalla { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Nombre de la Talla")]
        public string Nombre { get; set; }

        // Lista de IDs de tipos seleccionados
        [Display(Name = "Tipos")]
        public List<int> TiposSeleccionados { get; set; } = new List<int>();

        // Lista de todos los tipos disponibles (para mostrar en el formulario)
        public List<Tipo> TiposDisponibles { get; set; } = new List<Tipo>();
    }
}
