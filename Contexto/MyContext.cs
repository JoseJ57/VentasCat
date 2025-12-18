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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ===== CONFIGURACIÓN DE LA RELACIÓN MUCHOS-A-MUCHOS =====

            // Configurar la tabla intermedia TipoMaterial
            modelBuilder.Entity<TipoMaterial>()
                .HasKey(tm => tm.IdTipoMaterial);

            // Relación Material -> TipoMaterial
            modelBuilder.Entity<TipoMaterial>()
                .HasOne(tm => tm.Material)
                .WithMany(m => m.TipoMaterials)
                .HasForeignKey(tm => tm.IdMaterial)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Tipo -> TipoMaterial
            modelBuilder.Entity<TipoMaterial>()
                .HasOne(tm => tm.Tipo)
                .WithMany(t => t.TipoMateriales)
                .HasForeignKey(tm => tm.IdTipo)
                .OnDelete(DeleteBehavior.Cascade);

            // Índice único para evitar duplicados (un material no puede tener el mismo tipo 2 veces)
            modelBuilder.Entity<TipoMaterial>()
                .HasIndex(tm => new { tm.IdMaterial, tm.IdTipo })
                .IsUnique();

            // ===== CONFIGURACIÓN TALLA-TIPO (NUEVO) =====

            modelBuilder.Entity<TallaTipo>()
                .HasKey(tt => tt.IdTallaTipo);

            // Relación Talla -> TallaTipo
            modelBuilder.Entity<TallaTipo>()
                .HasOne(tt => tt.Talla)
                .WithMany(t => t.TallaTipos)
                .HasForeignKey(tt => tt.IdTalla)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Tipo -> TallaTipo
            modelBuilder.Entity<TallaTipo>()
                .HasOne(tt => tt.Tipo)
                .WithMany(t => t.TallaTipos)
                .HasForeignKey(tt => tt.IdTipo)
                .OnDelete(DeleteBehavior.Cascade);

            // Índice único para evitar duplicados
            modelBuilder.Entity<TallaTipo>()
                .HasIndex(tt => new { tt.IdTalla, tt.IdTipo })
                .IsUnique();
           

            // ===== CONFIGURACIÓN MATERIAL-ARTICULO =====
            modelBuilder.Entity<MaterialArticulo>()
                .HasKey(ma => ma.IdMaterialArticulo);

            modelBuilder.Entity<MaterialArticulo>()
                .HasOne(ma => ma.Articulo)
                .WithMany(a => a.MaterialArticulos)
                .HasForeignKey(ma => ma.IdArticulo)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MaterialArticulo>()
                .HasOne(ma => ma.Material)
                .WithMany(m => m.MaterialArticulos)
                .HasForeignKey(ma => ma.IdMaterial)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MaterialArticulo>()
                .HasIndex(ma => new { ma.IdArticulo, ma.IdMaterial })
                .IsUnique();

            // ===== CONFIGURACIÓN TALLA-ARTICULO =====
            modelBuilder.Entity<TallaArticulo>()
                .HasKey(ta => ta.IdTallaArticulo);

            modelBuilder.Entity<TallaArticulo>()
                .HasOne(ta => ta.Articulo)
                .WithMany(a => a.TallaArticulos)
                .HasForeignKey(ta => ta.IdArticulo)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TallaArticulo>()
                .HasOne(ta => ta.Talla)
                .WithMany(t => t.TallaArticulos)
                .HasForeignKey(ta => ta.IdTalla)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TallaArticulo>()
                .HasIndex(ta => new { ta.IdArticulo, ta.IdTalla })
                .IsUnique();
        
    }
    }
}
