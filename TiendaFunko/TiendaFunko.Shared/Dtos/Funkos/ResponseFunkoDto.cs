using System.Text.Json.Serialization;
using TiendaFunko.Shared.Dtos.Categorias;
using TiendaFunko.Shared.Dtos.Proveedores;

namespace TiendaFunko.Shared.Dtos.Funkos;

public record ResponseFunkoDto( 
    [property: JsonPropertyName("id")] long Id, 
    [property: JsonPropertyName("nombre")] string Nombre, 
    [property: JsonPropertyName("precio")] decimal Precio,
    [property: JsonPropertyName("stock")] int Stock, 
    [property: JsonPropertyName("imagen")] string Imagen, 
    [property: JsonPropertyName("categoria")] ResponseCategoriaDto ResponseCategoria, // DTO anidado de SQL
    [property: JsonPropertyName("proveedor")] ResponseProveedorDto ResponseProveedor, // DTO anidado de MongoDB
    [property: JsonPropertyName("created_at")] DateTime CreatedAt,
    [property: JsonPropertyName("updated_at")] DateTime? UpdatedAt 
);