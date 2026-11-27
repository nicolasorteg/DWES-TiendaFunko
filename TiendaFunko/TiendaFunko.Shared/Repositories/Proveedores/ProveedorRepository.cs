using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using TiendaFunko.Shared.Entity;
using TiendaFunko.Shared.Models;

namespace TiendaFunko.Shared.Repositories.Proveedores;

public class ProveedorRepository(AppMongoDbContext db) : IProveedorRepository {
    
    public async Task<Proveedor?> GetByIdAsync(string id) {
        if (!ObjectId.TryParse(id, out var objectId)) return null; // parse id -> objectid
        return await db.Proveedores
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == objectId && !p.IsDeleted);
    }
}