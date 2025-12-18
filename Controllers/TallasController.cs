using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentasSD.Contexto;
using VentasSD.Models;
using VentasSD.ViewModels;

namespace VentasSD.Controllers
{
    public class TallasController : Controller
    {
        private readonly MyContext _context;

        public TallasController(MyContext context)
        {
            _context = context;
        }

        // GET: Tallas
        public async Task<IActionResult> Index()
        {
            var tallas = await _context.Tallas
                 .Include(t => t.TallaTipos)
                     .ThenInclude(tt => tt.Tipo)
                 .OrderBy(t => t.Nombre)
                 .ToListAsync();

            return View(tallas);
        }

        // GET: Tallas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talla = await _context.Tallas
                .FirstOrDefaultAsync(m => m.IdTalla == id);
            if (talla == null)
            {
                return NotFound();
            }

            return View(talla);
        }

        // GET: Tallas/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new TallaViewModel
            {
                TiposDisponibles = await _context.Tipos
                    .OrderBy(t => t.Nombre)
                    .ToListAsync()
            };

            return View(viewModel);
        }

        // POST: Tallas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TallaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Crear la talla
                var talla = new Talla
                {
                    Nombre = viewModel.Nombre
                };

                _context.Tallas.Add(talla);
                await _context.SaveChangesAsync(); // Guardar para obtener el ID

                // Crear las relaciones con los tipos seleccionados
                if (viewModel.TiposSeleccionados != null && viewModel.TiposSeleccionados.Any())
                {
                    foreach (var idTipo in viewModel.TiposSeleccionados)
                    {
                        var tallaTipo = new TallaTipo
                        {
                            IdTalla = talla.IdTalla,
                            IdTipo = idTipo
                        };
                        _context.TallaTipos.Add(tallaTipo);
                    }

                    await _context.SaveChangesAsync();
                }

                TempData["Success"] = "Talla creada exitosamente";
                return RedirectToAction(nameof(Index));
            }

            // Si hay error, recargar los tipos disponibles
            viewModel.TiposDisponibles = await _context.Tipos
                .OrderBy(t => t.Nombre)
                .ToListAsync();

            return View(viewModel);
        }

        // GET: Tallas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talla = await _context.Tallas
                .Include(t => t.TallaTipos)
                .FirstOrDefaultAsync(t => t.IdTalla == id);

            if (talla == null)
            {
                return NotFound();
            }

            var viewModel = new TallaViewModel
            {
                IdTalla = talla.IdTalla,
                Nombre = talla.Nombre,
                TiposSeleccionados = talla.TallaTipos.Select(tt => tt.IdTipo).ToList(),
                TiposDisponibles = await _context.Tipos
                    .OrderBy(t => t.Nombre)
                    .ToListAsync()
            };

            return View(viewModel);
        }

        // POST: Tallas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TallaViewModel viewModel)
        {
            if (id != viewModel.IdTalla)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var talla = await _context.Tallas
                        .Include(t => t.TallaTipos)
                        .FirstOrDefaultAsync(t => t.IdTalla == id);

                    if (talla == null)
                    {
                        return NotFound();
                    }

                    // Actualizar propiedades de la talla
                    talla.Nombre = viewModel.Nombre;

                    // Eliminar relaciones existentes
                    _context.TallaTipos.RemoveRange(talla.TallaTipos);

                    // Agregar las nuevas relaciones
                    if (viewModel.TiposSeleccionados != null && viewModel.TiposSeleccionados.Any())
                    {
                        foreach (var idTipo in viewModel.TiposSeleccionados)
                        {
                            talla.TallaTipos.Add(new TallaTipo
                            {
                                IdTalla = talla.IdTalla,
                                IdTipo = idTipo
                            });
                        }
                    }

                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Talla actualizada exitosamente";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TallaExists(viewModel.IdTalla))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            viewModel.TiposDisponibles = await _context.Tipos
                .OrderBy(t => t.Nombre)
                .ToListAsync();

            return View(viewModel);
        }

        // GET: Tallas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talla = await _context.Tallas
                .Include(t => t.TallaTipos)
                    .ThenInclude(tt => tt.Tipo)
                .FirstOrDefaultAsync(t => t.IdTalla == id);

            if (talla == null)
            {
                return NotFound();
            }

            return View(talla);
        }

        // POST: Tallas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var talla = await _context.Tallas.FindAsync(id);

            if (talla != null)
            {
                _context.Tallas.Remove(talla);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Talla eliminada exitosamente";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TallaExists(int id)
        {
            return _context.Tallas.Any(e => e.IdTalla == id);
        }
    }
}
