using TiendaFunko.Shared.Dtos.Categorias;
using TiendaFunko.Shared.Models;

namespace TiendaFunko.Shared.Mappers;

public static class CategoriaMapper {
    
    // model -> resposedto
    public static ResponseCategoriaDto ToResponseDto(this Categoria categoria) => new(
        Id: categoria.Id,
        Nombre: categoria.Nombre
    );
    
    // createdto -> model
    public static Categoria ToEntity(this CreateCategoriaDto categoria) => new() {
        Nombre = categoria.Nombre,
        CreatedAt = DateTime.UtcNow
    };
    
    // updatedto -> model
    public static Categoria UpdateEntity(this UpdateCategoriaDto categoria) => new() {
        Nombre = categoria.Nombre,
        CreatedAt = DateTime.UtcNow
    };
}