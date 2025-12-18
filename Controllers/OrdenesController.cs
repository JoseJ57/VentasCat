using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VentasSD.Contexto;
using VentasSD.Dto;
using VentasSD.Models;

namespace VentasSD.Controllers
{
    public class OrdenesController : Controller
    {
        private readonly MyContext _context;

        public OrdenesController(MyContext context)
        {
            _context = context;
        }

        // GET: Ordenes
        public async Task<IActionResult> Index()
        {
            var myContext = _context.Ordenes.Include(o => o.Credito).Include(o => o.Envio).Include(o => o.Usuario);
            return View(await myContext.ToListAsync());
        }

        // GET: Ordenes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orden = await _context.Ordenes
                .Include(o => o.Credito)
                .Include(o => o.Envio)
                .Include(o => o.Usuario)
                .FirstOrDefaultAsync(m => m.IdOrden == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // GET: Ordenes/Create
        public IActionResult Create()
        {
            ViewBag.MetodoPagos = new SelectList(Enum.GetValues(typeof(MetodoPagos))
                .Cast<MetodoPagos>()
                .Select(r => new
                {
                    Id = (int)r,
                    Nombre = r.ToString()
                }),
                "Id", "Nombre");
            ViewBag.Estados = new SelectList(Enum.GetValues(typeof(Estados))
               .Cast<Estados>()
               .Select(r => new
               {
                   Id = (int)r,
                   Nombre = r.ToString()
               }),
               "Id", "Nombre");
            ViewData["IdCredito"] = new SelectList(_context.Creditos, "IdCredito", "IdCredito");
            ViewData["IdEnvio"] = new SelectList(_context.Envios, "IdEnvio", "Direccion");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            return View();
        }

        // POST: Ordenes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrden,Fecha,Pago,Total,Estado,ConEnvio,IdUsuario,IdCredito,IdEnvio")] Orden orden)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orden);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCredito"] = new SelectList(_context.Creditos, "IdCredito", "IdCredito", orden.IdCredito);
            ViewData["IdEnvio"] = new SelectList(_context.Envios, "IdEnvio", "Direccion", orden.IdEnvio);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario", orden.IdUsuario);
            return View(orden);
        }

        // GET: Ordenes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.MetodoPagos = new SelectList(Enum.GetValues(typeof(MetodoPagos))
               .Cast<MetodoPagos>()
               .Select(r => new
               {
                   Id = (int)r,
                   Nombre = r.ToString()
               }),
               "Id", "Nombre");
            ViewBag.Estados = new SelectList(Enum.GetValues(typeof(Estados))
               .Cast<Estados>()
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

            var orden = await _context.Ordenes.FindAsync(id);
            if (orden == null)
            {
                return NotFound();
            }
            ViewData["IdCredito"] = new SelectList(_context.Creditos, "IdCredito", "IdCredito", orden.IdCredito);
            ViewData["IdEnvio"] = new SelectList(_context.Envios, "IdEnvio", "Direccion", orden.IdEnvio);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario", orden.IdUsuario);
            return View(orden);
        }

        // POST: Ordenes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrden,Fecha,Pago,Total,Estado,ConEnvio,IdUsuario,IdCredito,IdEnvio")] Orden orden)
        {
            if (id != orden.IdOrden)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orden);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenExists(orden.IdOrden))
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
            ViewData["IdCredito"] = new SelectList(_context.Creditos, "IdCredito", "IdCredito", orden.IdCredito);
            ViewData["IdEnvio"] = new SelectList(_context.Envios, "IdEnvio", "Direccion", orden.IdEnvio);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario", orden.IdUsuario);
            return View(orden);
        }

        // GET: Ordenes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orden = await _context.Ordenes
                .Include(o => o.Credito)
                .Include(o => o.Envio)
                .Include(o => o.Usuario)
                .FirstOrDefaultAsync(m => m.IdOrden == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // POST: Ordenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orden = await _context.Ordenes.FindAsync(id);
            if (orden != null)
            {
                _context.Ordenes.Remove(orden);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenExists(int id)
        {
            return _context.Ordenes.Any(e => e.IdOrden == id);
        }
    }
}
