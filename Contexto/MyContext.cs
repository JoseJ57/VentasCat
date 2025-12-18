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

        public DbSet<Material> Materiales { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Talla> Tallas { get; set; }
        public DbSet<TallaArticulo> TallaArticulos { get; set; }
        public DbSet<TallaTipo> TallaTipos { get; set; }
        public DbSet<TipoMaterial> TipoMateriales { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<TipoPago> TipoPagos { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Transporte> Transportes { get; set; }
        public DbSet<Credito> Creditos { get; set; }
        public DbSet<DetalleOrden> DetalleOrdenes   { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<MaterialArticulo> MaterialArticulos { get; set; }

    }
}
