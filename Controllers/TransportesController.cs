using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VentasSD.Contexto;
using VentasSD.Models;
using VentasSD.Dto;

namespace VentasSD.Controllers
{
    public class TransportesController : Controller
    {
        private readonly MyContext _context;

        public TransportesController(MyContext context)
        {
            _context = context;
        }

        // GET: Transportes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transportes.ToListAsync());
        }

        // GET: Transportes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transporte = await _context.Transportes
                .FirstOrDefaultAsync(m => m.IdTransporte == id);
            if (transporte == null)
            {
                return NotFound();
            }

            return View(transporte);
        }

        // GET: Transportes/Create
        public IActionResult Create()
        {
            ViewBag.TipoTransportes = new SelectList(Enum.GetValues(typeof(TipoTransportes))
                .Cast<TipoTransportes>()
                .Select(r => new
                {
                    Id = (int)r,
                    Nombre = r.ToString()
                }),
                "Id", "Nombre");
            return View();
        }

        // POST: Transportes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTransporte,Tipo,Nombre,Empresa,Celular")] Transporte transporte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transporte);
        }

        // GET: Transportes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.TipoTransportes = new SelectList(Enum.GetValues(typeof(TipoTransportes))
                .Cast<TipoTransportes>()
                .Select(r => new
                {
                    Id = (int)r,
                    Nombre = r.ToString()
                }),
                "Id", "Nombre");
            if (id == null)
            {
                return NotFound();
            }

            var transporte = await _context.Transportes.FindAsync(id);
            if (transporte == null)
            {
                return NotFound();
            }
            return View(transporte);
        }

        // POST: Transportes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTransporte,Tipo,Nombre,Empresa,Celular")] Transporte transporte)
        {
            if (id != transporte.IdTransporte)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transporte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransporteExists(transporte.IdTransporte))
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
            return View(transporte);
        }

        // GET: Transportes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transporte = await _context.Transportes
                .FirstOrDefaultAsync(m => m.IdTransporte == id);
            if (transporte == null)
            {
                return NotFound();
            }

            return View(transporte);
        }

        // POST: Transportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transporte = await _context.Transportes.FindAsync(id);
            if (transporte != null)
            {
                _context.Transportes.Remove(transporte);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransporteExists(int id)
        {
            return _context.Transportes.Any(e => e.IdTransporte == id);
        }
    }
}
