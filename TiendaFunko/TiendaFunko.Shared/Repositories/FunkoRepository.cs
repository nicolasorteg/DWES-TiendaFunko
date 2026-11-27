using Microsoft.EntityFrameworkCore;
using TiendaFunko.Shared.Entity;
using TiendaFunko.Shared.Models;

namespace TiendaFunko.Shared.Repositories;

/// <summary>
/// Implementación EF Core del repositorio de Funkos.
/// Aplica filtrado por soft-delete (IsDeleted) en todas las lecturas.
/// </summary>
public sealed class FunkosRepository(AppDbContext context) : IFunkosRepository
{
    public async Task<IReadOnlyList<Funko>> GetAllAsync() =>
        await context.Funkos
            .AsNoTracking()
            .Where(f => !f.IsDeleted)
            .OrderBy(f => f.Nombre)
            .ToListAsync();

    public async Task<Funko?> GetByIdAsync(long id) =>
        await context.Funkos
            .AsNoTracking()
            .Include(f => f.Categoria)
            .FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);
    
    public async Task<Funko?> GetByNameAsync(string nombre) =>
        await context.Funkos
            .AsNoTracking()
            .Include(f => f.Categoria)
            .FirstOrDefaultAsync(f => f.Nombre == nombre && !f.IsDeleted);

    public async Task<Funko> AddAsync(Funko entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.IsDeleted = false;

        await context.Funkos.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<Funko?> UpdateAsync(Funko entity)
    {
        // comprueba que exista
        var existing = await context.Funkos
            .FirstOrDefaultAsync(f => f.Id == entity.Id && !f.IsDeleted);
        if (existing is null) return null;

        // Copiamos solo los campos mutables (no Id, CreatedAt ni soft-delete).
        existing.Nombre      = entity.Nombre;
        existing.Precio      = entity.Precio;
        existing.Stock       = entity.Stock;
        existing.Imagen      = entity.Imagen;
        existing.CategoriaId = entity.CategoriaId;
        existing.ProveedorId = entity.ProveedorId;
        existing.UpdatedAt   = DateTime.UtcNow;

        await context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        // comprueba que exista
        var funko = await context.Funkos
            .FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);
        if (funko is null) return false;

        // Soft-delete coherente con el modelo (IsDeleted / DeletedAt).
        funko.IsDeleted = true;
        funko.DeletedAt = DateTime.UtcNow;
        await context.SaveChangesAsync();
        return true;
    }
}