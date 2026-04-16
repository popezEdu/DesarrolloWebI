using System;
using Microsoft.EntityFrameworkCore;
using TiendaComida.Entidades;

namespace TiendaComida.Data;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Venta> Ventas { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Detalle> Detalles { get; set; }
    public DbSet<Factura> Facturas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Detalles de la tabla Cliente

        modelBuilder.Entity<Cliente>()
            .ToTable("Cliente");

        modelBuilder.Entity<Cliente>()
            .Property(x => x.Nombre)
            .HasMaxLength(50);

        modelBuilder.Entity<Cliente>()
            .Property(x => x.Extension)
            .HasMaxLength(2);

        // Detalles de la tabla Venta

        modelBuilder.Entity<Venta>()
            .ToTable("Venta");

        modelBuilder.Entity<Venta>()
            .HasOne(x => x.Cliente)
            .WithMany(v => v.Ventas)
            .HasForeignKey(x => x.ClienteId);

        modelBuilder.Entity<Venta>()
            .Property(x => x.Total)
            .HasColumnType("decimal(8,2)");

        // Plato

        modelBuilder.Entity<Producto>()
            .ToTable("Producto");

        modelBuilder.Entity<Producto>()
            .Property(x => x.Costo)
            .HasColumnType("decimal(7,2)");

        modelBuilder.Entity<Producto>()
            .Property(x => x.Nombre)
            .HasMaxLength(35);

        modelBuilder.Entity<Producto>()
            .Property(x => x.Descripcion)
            .HasMaxLength(100);

        modelBuilder.Entity<Producto>()
            .Property(x => x.Clasificacion)
            .HasConversion<string>();

        // Detalle
        modelBuilder.Entity<Detalle>()
            .ToTable("Detalle");

        modelBuilder.Entity<Detalle>()
            .Property(x => x.CostoTotal)
            .HasColumnType("decimal(7,2)");

        modelBuilder.Entity<Detalle>()
            .Property(x => x.CostoUnitario)
            .HasColumnType("decimal(7,2)");

        modelBuilder.Entity<Detalle>()
        .HasOne(d => d.Producto)
        .WithMany(p => p.Detalle)
        .HasForeignKey(d => d.ProductoId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Detalle>()
            .HasOne(d => d.Venta)
            .WithMany(v => v.Detalle)
            .HasForeignKey(d => d.VentaId)
            .OnDelete(DeleteBehavior.Restrict);

        // Factura
        modelBuilder.Entity<Factura>()
            .ToTable("Factura");

        modelBuilder.Entity<Factura>()
            .HasOne(f => f.Venta)
            .WithOne(v => v.Factura)
            .HasForeignKey<Factura>(f => f.VentaId)
            .OnDelete(DeleteBehavior.Restrict);
    }

}
