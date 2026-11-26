using Microsoft.EntityFrameworkCore;
using TiendaFunko.Shared.IdGenerators;
using TiendaFunko.Shared.Models;

namespace TiendaFunko.Shared.Entity;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) {
    
    public DbSet<Categoria> Categorias { get; set; } = null!;
    public DbSet<Funko> Funkos { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        // config categoria
        modelBuilder.Entity<Categoria>(e => {
            e.ToTable("Categorias");
            e.HasKey(c => c.Id);
            
            // id estilo yt
            e.Property(c => c.Id)
                .HasMaxLength(11)
                .HasValueGenerator<YouTubeIdValueGenerator>()
                .ValueGeneratedOnAdd();

            e.Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            e.Property(c => c.CreatedAt)
                .IsRequired();
            
            e.Property(c => c.IsDeleted)
                .HasDefaultValue(false);

            // soft delete
            e.HasQueryFilter(c => !c.IsDeleted);
        });
        
        // condif funko
        modelBuilder.Entity<Funko>(e => {
            e.ToTable("funkos"); 
            e.HasKey(f => f.Id);

            // id autoincrement
            e.Property(f => f.Id)
                .ValueGeneratedOnAdd();
            
            e.Property(f => f.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            e.Property(f => f.Precio)
                .IsRequired()
                .HasPrecision(10, 2);

            e.Property(f => f.Stock)
                .IsRequired();

            e.Property(f => f.Imagen)
                .HasMaxLength(255);
            
            // fk de categoria
            e.Property(f => f.CategoriaId) 
                .IsRequired() 
                .HasMaxLength(11);
            
            e.HasOne(f => f.Categoria)
                .WithMany(c => c.Funkos)
                .HasForeignKey(f => f.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            // fk de proveedor (object id)
            e.Property(f => f.ProveedorId)
                .IsRequired()
                .HasMaxLength(24);

            e.Property(f => f.CreatedAt)
                .IsRequired();
            
            e.Property(f => f.IsDeleted) 
                .HasDefaultValue(false);
            
            // soft delete
            e.HasQueryFilter(f => !f.IsDeleted);
        });
    }
}