using TiendaFunko.Shared.Models;

namespace TiendaFunko.Shared.Repositories.Proveedores;

/// <summary>
/// interfaz para proveedor repository
/// </summary>
public interface IProveedorRepository {
    Task<Proveedor?> GetByIdAsync(string id);
}