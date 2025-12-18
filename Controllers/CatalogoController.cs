using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentasSD.Contexto;
using VentasSD.Dto;
using VentasSD.Models;
using VentasSD.ViewModels;

namespace VentasSD.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly MyContext _context;

        public CatalogoController(MyContext context)
        {
            _context = context;
        }

        // GET: Catalogo
        public async Task<IActionResult> Index(int? idTipo, string busqueda)
        {
            var query = _context.Articulos
                .Include(a => a.Tipo)
                .Include(a => a.Marca)
                .Where(a => a.Estado == EstadoArticulos.Disponible);

            // Filtrar por tipo si se seleccionó
            if (idTipo.HasValue && idTipo.Value > 0)
            {
                query = query.Where(a => a.IdTipo == idTipo.Value);
            }

            // Filtrar por búsqueda
            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                query = query.Where(a =>
                    a.Nombre.Contains(busqueda) ||
                    a.Descripcion.Contains(busqueda) ||
                    a.TipoArticulo.Contains(busqueda));
            }

            var viewModel = new CatalogoViewModel
            {
                Articulos = await query.OrderBy(a => a.Nombre).ToListAsync(),
                Tipos = await _context.Tipos.OrderBy(t => t.Nombre).ToListAsync(),
                TipoSeleccionado = idTipo,
                BusquedaTexto = busqueda
            };

            return View(viewModel);
        }

        // GET: Catalogo/Detalle/5
        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos
                .Include(a => a.Tipo)
                .Include(a => a.Marca)
                .Include(a => a.TallaArticulos)
                    .ThenInclude(ta => ta.Talla)
                .Include(a => a.MaterialArticulos)
                    .ThenInclude(ma => ma.Material)
                .FirstOrDefaultAsync(a => a.IdArticulo == id);

            if (articulo == null)
            {
                return NotFound();
            }

            var viewModel = new DetalleArticuloViewModel
            {
                Articulo = articulo,
                TallasDisponibles = articulo.TallaArticulos.Select(ta => ta.Talla).ToList(),
                MaterialesDisponibles = articulo.MaterialArticulos.Select(ma => ma.Material).ToList()
            };

            return View(viewModel);
        }
    }
}