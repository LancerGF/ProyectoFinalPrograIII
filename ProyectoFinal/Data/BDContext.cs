using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProyectoFinal.Models;

namespace ProyectoFinal.Data
{
    public partial class BDContext : DbContext
    {

        public BDContext(DbContextOptions<BDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<InventarioProducto> InventarioProductos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<ProductosFactura> ProductosFacturas { get; set; } = null!;
        public virtual DbSet<TipoProducto> TipoProductos { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factura>(entity =>
            {
                entity.ToTable("Factura");

                entity.Property(e => e.FechaCompra).HasColumnType("date");
            });

            modelBuilder.Entity<InventarioProducto>(entity =>
            {
                entity.ToTable("InventarioProducto");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.InventarioProductos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventarioProducto_Producto");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.Descripcion).HasMaxLength(300);

                entity.Property(e => e.Marca).HasMaxLength(150);

                entity.Property(e => e.NombreProducto).HasMaxLength(150);

                entity.HasOne(d => d.IdTipoProductoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdTipoProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_TipoProducto");
            });

            modelBuilder.Entity<ProductosFactura>(entity =>
            {
                entity.ToTable("ProductosFactura");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.ProductosFacturas)
                    .HasForeignKey(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductosFactura_Factura");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.ProductosFacturas)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductosFactura_Producto");
            });

            modelBuilder.Entity<TipoProducto>(entity =>
            {
                entity.ToTable("TipoProducto");

                entity.Property(e => e.Tipo).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
