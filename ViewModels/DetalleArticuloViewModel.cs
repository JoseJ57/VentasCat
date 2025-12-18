
using VentasSD.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VentasSD.Dto;

namespace VentasSD.ViewModels
{
    public class DetalleArticuloViewModel
    {
        public Articulo Articulo { get; set; }
        public List<Talla> TallasDisponibles { get; set; } = new List<Talla>();
        public List<Material> MaterialesDisponibles { get; set; } = new List<Material>();
    }
}
