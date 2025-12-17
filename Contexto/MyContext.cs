using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using VentasSD.Models;

namespace VentasSD.Contexto
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        public DbSet<Material> Materials { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Talla> Tallas { get; set; }
        public DbSet<TallaArticulo> TallaArticulos { get; set; }
        public DbSet<TallaTipo> TallaTipos { get; set; }
        public DbSet<TipoMaterial> tipoMaterials { get; set; }
    }
}
