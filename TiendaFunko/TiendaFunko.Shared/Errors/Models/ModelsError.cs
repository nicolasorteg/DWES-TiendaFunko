using TiendaFunko.Shared.Errors.Common;

namespace TiendaFunko.Shared.Errors.Models;

public static class ModelsError {
    
    // 404
    public sealed record NotFound(string Id)
        : DomainError($"No se ha encontrado el modelo con el identificador: {Id}");
    
    // 400
    public sealed record Validation(string Mensaje)
        : DomainError(Mensaje);

    // regla de negocio
    public sealed record FunkoAsociado()
        : DomainError($"No se puede eliminar el modelo puesto que tiene un Funko asociado.");
    
    // 404 (la categoría del funko no existe o está borrada)
    public sealed record CategoriaNotFound(string CategoriaId)
        : DomainError($"No se ha encontrado la categoría con el identificador: {CategoriaId}");

    // 404 (el proveedor del funko no existe o está borrado)
    public sealed record ProveedorNotFound(string ProveedorId)
        : DomainError($"No se ha encontrado el proveedor con el identificador: {ProveedorId}");
}

/// <summary>
/// Factory para crear errores de los modelos
/// </summary>
public class ModelErrors {
    
    public static DomainError NotFound(string id) =>
        new ModelsError.NotFound(id);

    public static DomainError Validation(string mensaje) =>
        new ModelsError.Validation(mensaje);

    public static DomainError FunkoAsociado() =>
        new ModelsError.FunkoAsociado();
    
    public static DomainError CategoriaNotFound(string categoriaId) =>
        new ModelsError.CategoriaNotFound(categoriaId);

    public static DomainError ProveedorNotFound(string proveedorId) =>
        new ModelsError.ProveedorNotFound(proveedorId);
}