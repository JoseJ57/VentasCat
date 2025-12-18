using VentasSD.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentasSD.ViewModels
{
    public class MaterialViewModel
    {
        public int IdMaterial { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        // Lista de IDs de tipos seleccionados
        public List<int> TiposSeleccionados { get; set; } = new List<int>();

        // Lista de todos los tipos disponibles (para el combo)
        public List<Tipo> TiposDisponibles { get; set; } = new List<Tipo>();
    }
}
