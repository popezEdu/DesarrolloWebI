using System;
using Microsoft.EntityFrameworkCore;
using TiendaComida.Entidades;

namespace TiendaComida.Data;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Venta> Ventas { get; set; }

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
            .WithMany(x => x.Ventas)
            .HasForeignKey(x => x.ClienteId);

        modelBuilder.Entity<Venta>()
        .Property(x => x.Total)
        .HasColumnType("decimal(6,2)");
    }

}
