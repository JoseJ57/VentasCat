using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Administrador")]

    public class MaterialesController : Controller
    {
        private readonly MyContext _context;

        public MaterialesController(MyContext context)
        {
            _context = context;
        }

        // GET: Materiales
        public async Task<IActionResult> Index()
        {
            return View(await _context.Materiales.ToListAsync());
        }

        // GET: Materiales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materiales
                .FirstOrDefaultAsync(m => m.IdMaterial == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // GET: Materiales/Create
        // GET: Materiales/Create
        public async Task<IActionResult> Create()
        {
            // Creas el ViewModel (no el modelo Material)
            var viewModel = new MaterialViewModel
            {
                TiposDisponibles = await _context.Tipos.ToListAsync()
            };

            return View(viewModel); // Envías el ViewModel a la vista
        }

        // POST: Materiales/Create
        [HttpPost]
        public async Task<IActionResult> Create(MaterialViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Aquí SÍ creas el modelo Material para guardar en BD
                var material = new Material
                {
                    Nombre = viewModel.Nombre
                };

                _context.Materiales.Add(material);
                await _context.SaveChangesAsync();

                // Guardas las relaciones
                foreach (var idTipo in viewModel.TiposSeleccionados)
                {
                    _context.TipoMateriales.Add(new TipoMaterial
                    {
                        IdMaterial = material.IdMaterial,
                        IdTipo = idTipo
                    });
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        // GET: Materiales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materiales.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }
            return View(material);
        }

        // POST: Materiales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMaterial,Nombre")] Material material)
        {
            if (id != material.IdMaterial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(material);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialExists(material.IdMaterial))
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
            return View(material);
        }

        // GET: Materiales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materiales
                .FirstOrDefaultAsync(m => m.IdMaterial == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // POST: Materiales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var material = await _context.Materiales.FindAsync(id);
            if (material != null)
            {
                _context.Materiales.Remove(material);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialExists(int id)
        {
            return _context.Materiales.Any(e => e.IdMaterial == id);
        }
    }
}
