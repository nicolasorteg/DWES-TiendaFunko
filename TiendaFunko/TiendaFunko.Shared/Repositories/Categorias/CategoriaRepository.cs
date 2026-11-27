using Microsoft.EntityFrameworkCore;
using TiendaFunko.Shared.Entity;
using TiendaFunko.Shared.Models;

namespace TiendaFunko.Shared.Repositories.Categorias;

public class CategoriaRepository(AppDbContext db) : ICategoriaRepository {
    
    public async Task<Categoria?> GetByIdAsync(string id) =>
        await db.Categorias.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted).ConfigureAwait(false);
}