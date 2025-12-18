using VentasSD.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VentasSD.Dto;
namespace VentasSD.ViewModels
{
    public class ArticuloViewModel
    {
        public int IdArticulo { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "El nombre no puede tener más de 30 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(100, ErrorMessage = "La descripción no puede tener más de 100 caracteres")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Las recomendaciones son obligatorias")]
        [StringLength(100, ErrorMessage = "Las recomendaciones no pueden tener más de 100 caracteres")]
        [Display(Name = "Recomendaciones")]
        public string Recomendaciones { get; set; }

        [Required(ErrorMessage = "El eslogan es obligatorio")]
        [StringLength(50, ErrorMessage = "El eslogan no puede tener más de 50 caracteres")]
        [Display(Name = "Eslogan")]
        public string Eslogan { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, 999999.99, ErrorMessage = "El precio debe ser mayor a 0")]
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [Display(Name = "Estado")]
        public EstadoArticulos Estado { get; set; }

        [Display(Name = "Imagen")]
        public string? Imagen { get; set; }

        [Display(Name = "Cargar Imagen")]
        public IFormFile? ImagenFile { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        [Display(Name = "Categoría")]
        public Categorias Categoria { get; set; }

        [Required(ErrorMessage = "El tipo de artículo es obligatorio")]
        [StringLength(20, ErrorMessage = "El tipo no puede tener más de 20 caracteres")]
        [Display(Name = "Tipo de Artículo")]
        public string TipoArticulo { get; set; }

        [Required(ErrorMessage = "La marca es obligatoria")]
        [Display(Name = "Marca")]
        public int IdMarca { get; set; }

        [Required(ErrorMessage = "El tipo es obligatorio")]
        [Display(Name = "Tipo")]
        public int IdTipo { get; set; }

        // Para mostrar las opciones
        public List<Marca> MarcasDisponibles { get; set; } = new List<Marca>();
        public List<Tipo> TiposDisponibles { get; set; } = new List<Tipo>();

        // Para las selecciones múltiples (se llenarán dinámicamente)
        public List<int> TallasSeleccionadas { get; set; } = new List<int>();
        public List<int> MaterialesSeleccionados { get; set; } = new List<int>();
    }
}
