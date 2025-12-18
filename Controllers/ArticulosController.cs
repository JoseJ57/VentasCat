using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentasSD.Models;
using VentasSD.ViewModels;
using VentasSD.Dto;
using VentasSD.Contexto;
using Microsoft.AspNetCore.Authorization;

namespace VentasSD.Controllers
{
    [Authorize(Roles = "Administrador")]


    public class ArticulosController : Controller
    {
        private readonly MyContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ArticulosController(MyContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Articulos
        public async Task<IActionResult> Index()
        {
            var articulos = await _context.Articulos
                .Include(a => a.Marca)
                .Include(a => a.Tipo)
                .Include(a => a.TallaArticulos)
                    .ThenInclude(ta => ta.Talla)
                .Include(a => a.MaterialArticulos)
                    .ThenInclude(ma => ma.Material)
                .OrderBy(a => a.Nombre)
                .ToListAsync();

            return View(articulos);
        }

        // GET: Articulos/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new ArticuloViewModel
            {
                MarcasDisponibles = await _context.Marcas.OrderBy(m => m.Nombre).ToListAsync(),
                TiposDisponibles = await _context.Tipos.OrderBy(t => t.Nombre).ToListAsync(),
                Estado = EstadoArticulos.Disponible // Valor por defecto
            };

            return View(viewModel);
        }

        // POST: Articulos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArticuloViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Manejar la imagen
                string imagenPath = "default.jpg";
                if (viewModel.ImagenFile != null)
                {
                    imagenPath = await GuardarImagen(viewModel.ImagenFile);
                }

                // Crear el artículo
                var articulo = new Articulo
                {
                    Nombre = viewModel.Nombre,
                    Descripcion = viewModel.Descripcion,
                    Recomendaciones = viewModel.Recomendaciones,
                    Eslogan = viewModel.Eslogan,
                    Precio = viewModel.Precio,
                    Estado = viewModel.Estado,
                    Imagen = imagenPath,
                    Categoria = viewModel.Categoria,
                    TipoArticulo = viewModel.TipoArticulo,
                    IdMarca = viewModel.IdMarca,
                    IdTipo = viewModel.IdTipo
                };

                _context.Articulos.Add(articulo);
                await _context.SaveChangesAsync();

                // Agregar tallas seleccionadas
                if (viewModel.TallasSeleccionadas != null && viewModel.TallasSeleccionadas.Any())
                {
                    foreach (var idTalla in viewModel.TallasSeleccionadas)
                    {
                        _context.TallaArticulos.Add(new TallaArticulo
                        {
                            IdArticulo = articulo.IdArticulo,
                            IdTalla = idTalla
                        });
                    }
                }

                // Agregar materiales seleccionados
                if (viewModel.MaterialesSeleccionados != null && viewModel.MaterialesSeleccionados.Any())
                {
                    foreach (var idMaterial in viewModel.MaterialesSeleccionados)
                    {
                        _context.MaterialArticulos.Add(new MaterialArticulo
                        {
                            IdArticulo = articulo.IdArticulo,
                            IdMaterial = idMaterial
                        });
                    }
                }

                await _context.SaveChangesAsync();

                TempData["Success"] = "Artículo creado exitosamente";
                return RedirectToAction(nameof(Index));
            }

            // Recargar datos en caso de error
            viewModel.MarcasDisponibles = await _context.Marcas.OrderBy(m => m.Nombre).ToListAsync();
            viewModel.TiposDisponibles = await _context.Tipos.OrderBy(t => t.Nombre).ToListAsync();
            return View(viewModel);
        }

        // API ENDPOINT: Obtener tallas por tipo
        [HttpGet]
        public async Task<IActionResult> ObtenerTallasPorTipo(int idTipo)
        {
            var tallas = await _context.TallaTipos
                .Where(tt => tt.IdTipo == idTipo)
                .Select(tt => new TallaDto
                {
                    IdTalla = tt.IdTalla,
                    Nombre = tt.Talla.Nombre
                })
                .OrderBy(t => t.Nombre)
                .ToListAsync();

            return Json(tallas);
        }

        // API ENDPOINT: Obtener materiales por tipo
        [HttpGet]
        public async Task<IActionResult> ObtenerMaterialesPorTipo(int idTipo)
        {
            var materiales = await _context.TipoMateriales
                .Where(tm => tm.IdTipo == idTipo)
                .Select(tm => new MaterialDto
                {
                    IdMaterial = tm.IdMaterial,
                    Nombre = tm.Material.Nombre
                })
                .OrderBy(m => m.Nombre)
                .ToListAsync();

            return Json(materiales);
        }

        // Método auxiliar para guardar imagen
        private async Task<string> GuardarImagen(IFormFile imagen)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "articulos");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + imagen.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imagen.CopyToAsync(fileStream);
            }

            return uniqueFileName;
        }

        // GET: Articulos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos
                .Include(a => a.TallaArticulos)
                .Include(a => a.MaterialArticulos)
                .FirstOrDefaultAsync(a => a.IdArticulo == id);

            if (articulo == null)
            {
                return NotFound();
            }

            var viewModel = new ArticuloViewModel
            {
                IdArticulo = articulo.IdArticulo,
                Nombre = articulo.Nombre,
                Descripcion = articulo.Descripcion,
                Recomendaciones = articulo.Recomendaciones,
                Eslogan = articulo.Eslogan,
                Precio = articulo.Precio,
                Estado = articulo.Estado,
                Imagen = articulo.Imagen,
                Categoria = articulo.Categoria,
                TipoArticulo = articulo.TipoArticulo,
                IdMarca = articulo.IdMarca,
                IdTipo = articulo.IdTipo,
                TallasSeleccionadas = articulo.TallaArticulos.Select(ta => ta.IdTalla).ToList(),
                MaterialesSeleccionados = articulo.MaterialArticulos.Select(ma => ma.IdMaterial).ToList(),
                MarcasDisponibles = await _context.Marcas.OrderBy(m => m.Nombre).ToListAsync(),
                TiposDisponibles = await _context.Tipos.OrderBy(t => t.Nombre).ToListAsync()
            };

            return View(viewModel);
        }

        // POST: Articulos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ArticuloViewModel viewModel)
        {
            if (id != viewModel.IdArticulo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var articulo = await _context.Articulos
                        .Include(a => a.TallaArticulos)
                        .Include(a => a.MaterialArticulos)
                        .FirstOrDefaultAsync(a => a.IdArticulo == id);

                    if (articulo == null)
                    {
                        return NotFound();
                    }

                    // Actualizar propiedades
                    articulo.Nombre = viewModel.Nombre;
                    articulo.Descripcion = viewModel.Descripcion;
                    articulo.Recomendaciones = viewModel.Recomendaciones;
                    articulo.Eslogan = viewModel.Eslogan;
                    articulo.Precio = viewModel.Precio;
                    articulo.Estado = viewModel.Estado;
                    articulo.Categoria = viewModel.Categoria;
                    articulo.TipoArticulo = viewModel.TipoArticulo;
                    articulo.IdMarca = viewModel.IdMarca;
                    articulo.IdTipo = viewModel.IdTipo;

                    // Actualizar imagen si se cargó una nueva
                    if (viewModel.ImagenFile != null)
                    {
                        // Eliminar imagen anterior si no es la default
                        if (articulo.Imagen != "default.jpg")
                        {
                            EliminarImagen(articulo.Imagen);
                        }
                        articulo.Imagen = await GuardarImagen(viewModel.ImagenFile);
                    }

                    // Actualizar tallas
                    _context.TallaArticulos.RemoveRange(articulo.TallaArticulos);
                    if (viewModel.TallasSeleccionadas != null && viewModel.TallasSeleccionadas.Any())
                    {
                        foreach (var idTalla in viewModel.TallasSeleccionadas)
                        {
                            articulo.TallaArticulos.Add(new TallaArticulo
                            {
                                IdArticulo = articulo.IdArticulo,
                                IdTalla = idTalla
                            });
                        }
                    }

                    // Actualizar materiales
                    _context.MaterialArticulos.RemoveRange(articulo.MaterialArticulos);
                    if (viewModel.MaterialesSeleccionados != null && viewModel.MaterialesSeleccionados.Any())
                    {
                        foreach (var idMaterial in viewModel.MaterialesSeleccionados)
                        {
                            articulo.MaterialArticulos.Add(new MaterialArticulo
                            {
                                IdArticulo = articulo.IdArticulo,
                                IdMaterial = idMaterial
                            });
                        }
                    }

                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Artículo actualizado exitosamente";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticuloExists(viewModel.IdArticulo))
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

            viewModel.MarcasDisponibles = await _context.Marcas.OrderBy(m => m.Nombre).ToListAsync();
            viewModel.TiposDisponibles = await _context.Tipos.OrderBy(t => t.Nombre).ToListAsync();
            return View(viewModel);
        }

        private void EliminarImagen(string nombreImagen)
        {
            string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "articulos", nombreImagen);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
        }

        private bool ArticuloExists(int id)
        {
            return _context.Articulos.Any(e => e.IdArticulo == id);
        }
    }
}