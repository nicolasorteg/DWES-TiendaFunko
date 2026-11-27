using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using TiendaFunko.Shared.Models;

namespace TiendaFunko.Shared.Entity;

public class AppMongoDbContext : DbContext{

    public AppMongoDbContext(DbContextOptions<AppMongoDbContext> options) : base(options) {
        // evita fallos con transacciones (MongoDB local sin replica set)
        Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;
    }
    
    public DbSet<Proveedor> Proveedores => Set<Proveedor>(); // table

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Proveedor>().ToCollection("proveedores");
    }
}