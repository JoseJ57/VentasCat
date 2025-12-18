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

namespace VentasSD.Controllers
{
    [Authorize(Roles = "Administrador,Vendedor")]

    public class TipoPagosController : Controller
    {
        private readonly MyContext _context;

        public TipoPagosController(MyContext context)
        {
            _context = context;
        }

        // GET: TipoPagos
        public async Task<IActionResult> Index()
        {
            var myContext = _context.TipoPagos.Include(t => t.Credito).Include(t => t.Orden);
            return View(await myContext.ToListAsync());
        }

        // GET: TipoPagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPago = await _context.TipoPagos
                .Include(t => t.Credito)
                .Include(t => t.Orden)
                .FirstOrDefaultAsync(m => m.IdTipoPago == id);
            if (tipoPago == null)
            {
                return NotFound();
            }

            return View(tipoPago);
        }

        // GET: TipoPagos/Create
        public IActionResult Create()
        {
            ViewData["IdCredito"] = new SelectList(_context.Creditos, "IdCredito", "IdCredito");
            ViewData["IdOrden"] = new SelectList(_context.Ordenes, "IdOrden", "IdOrden");
            return View();
        }

        // POST: TipoPagos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoPago,Fecha,Comprobante,Codigo,Estado,IdOrden,IdCredito")] TipoPago tipoPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCredito"] = new SelectList(_context.Creditos, "IdCredito", "IdCredito", tipoPago.IdCredito);
            ViewData["IdOrden"] = new SelectList(_context.Ordenes, "IdOrden", "IdOrden", tipoPago.IdOrden);
            return View(tipoPago);
        }

        // GET: TipoPagos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPago = await _context.TipoPagos.FindAsync(id);
            if (tipoPago == null)
            {
                return NotFound();
            }
            ViewData["IdCredito"] = new SelectList(_context.Creditos, "IdCredito", "IdCredito", tipoPago.IdCredito);
            ViewData["IdOrden"] = new SelectList(_context.Ordenes, "IdOrden", "IdOrden", tipoPago.IdOrden);
            return View(tipoPago);
        }

        // POST: TipoPagos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoPago,Fecha,Comprobante,Codigo,Estado,IdOrden,IdCredito")] TipoPago tipoPago)
        {
            if (id != tipoPago.IdTipoPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPagoExists(tipoPago.IdTipoPago))
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
            ViewData["IdCredito"] = new SelectList(_context.Creditos, "IdCredito", "IdCredito", tipoPago.IdCredito);
            ViewData["IdOrden"] = new SelectList(_context.Ordenes, "IdOrden", "IdOrden", tipoPago.IdOrden);
            return View(tipoPago);
        }

        // GET: TipoPagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPago = await _context.TipoPagos
                .Include(t => t.Credito)
                .Include(t => t.Orden)
                .FirstOrDefaultAsync(m => m.IdTipoPago == id);
            if (tipoPago == null)
            {
                return NotFound();
            }

            return View(tipoPago);
        }

        // POST: TipoPagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoPago = await _context.TipoPagos.FindAsync(id);
            if (tipoPago != null)
            {
                _context.TipoPagos.Remove(tipoPago);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPagoExists(int id)
        {
            return _context.TipoPagos.Any(e => e.IdTipoPago == id);
        }
    }
}
