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
    public class EnviosController : Controller
    {
        private readonly MyContext _context;

        public EnviosController(MyContext context)
        {
            _context = context;
        }

        // GET: Envios
        public async Task<IActionResult> Index()
        {
            var myContext = _context.Envios.Include(e => e.Transporte);
            return View(await myContext.ToListAsync());
        }

        // GET: Envios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var envio = await _context.Envios
                .Include(e => e.Transporte)
                .FirstOrDefaultAsync(m => m.IdEnvio == id);
            if (envio == null)
            {
                return NotFound();
            }

            return View(envio);
        }

        // GET: Envios/Create
        public IActionResult Create()
        {
            ViewBag.EstadosEnvio = new SelectList(Enum.GetValues(typeof(EstadosEnvio))
                .Cast<EstadosEnvio>()
                .Select(r => new
                {
                    Id = (int)r,
                    Nombre = r.ToString()
                }),
                "Id", "Nombre");
            ViewData["IdTransporte"] = new SelectList(_context.Transportes, "IdTransporte", "Empresa");
            return View();
        }

        // POST: Envios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEnvio,Direccion,FechaEntrega,Costo,Estado,PagoIncluido,IdTransporte")] Envio envio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(envio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTransporte"] = new SelectList(_context.Transportes, "IdTransporte", "Celular", envio.IdTransporte);
            return View(envio);
        }

        // GET: Envios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.EstadosEnvio = new SelectList(Enum.GetValues(typeof(EstadosEnvio))
                .Cast<EstadosEnvio>()
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

            var envio = await _context.Envios.FindAsync(id);
            if (envio == null)
            {
                return NotFound();
            }
            ViewData["IdTransporte"] = new SelectList(_context.Transportes, "IdTransporte", "Celular", envio.IdTransporte);
            return View(envio);
        }

        // POST: Envios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEnvio,Direccion,FechaEntrega,Costo,Estado,PagoIncluido,IdTransporte")] Envio envio)
        {
            if (id != envio.IdEnvio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(envio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnvioExists(envio.IdEnvio))
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
            ViewData["IdTransporte"] = new SelectList(_context.Transportes, "IdTransporte", "Celular", envio.IdTransporte);
            return View(envio);
        }

        // GET: Envios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var envio = await _context.Envios
                .Include(e => e.Transporte)
                .FirstOrDefaultAsync(m => m.IdEnvio == id);
            if (envio == null)
            {
                return NotFound();
            }

            return View(envio);
        }

        // POST: Envios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var envio = await _context.Envios.FindAsync(id);
            if (envio != null)
            {
                _context.Envios.Remove(envio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnvioExists(int id)
        {
            return _context.Envios.Any(e => e.IdEnvio == id);
        }
    }
}
