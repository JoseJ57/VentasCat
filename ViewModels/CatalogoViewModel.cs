using VentasSD.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VentasSD.Dto;
namespace VentasSD.ViewModels
{
    public class CatalogoViewModel
    {
        public List<Articulo> Articulos { get; set; } = new List<Articulo>();
        public List<Tipo> Tipos { get; set; } = new List<Tipo>();
        public int? TipoSeleccionado { get; set; }
        public string? BusquedaTexto { get; set; }
    }
}
