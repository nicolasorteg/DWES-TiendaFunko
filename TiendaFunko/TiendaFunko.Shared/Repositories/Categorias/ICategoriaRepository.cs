using TiendaFunko.Shared.Models;

namespace TiendaFunko.Shared.Repositories.Categorias;

/// <summary>
/// interfaz para categoria repository
/// </summary>
public interface ICategoriaRepository {
    Task<Categoria?> GetByIdAsync(string id);
}