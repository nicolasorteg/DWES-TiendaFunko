using System.Text.Json.Serialization;

namespace TiendaFunko.Shared.Dtos.Categorias;

public record ResponseCategoriaDto( 
    [property: JsonPropertyName("id")] string Id, // id estilo yt
    [property: JsonPropertyName("nombre")] string Nombre 
);