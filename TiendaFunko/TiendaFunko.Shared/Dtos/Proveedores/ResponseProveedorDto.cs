using System.Text.Json.Serialization;

namespace TiendaFunko.Shared.Dtos.Proveedores;

public record ResponseProveedorDto( 
    [property: JsonPropertyName("id")] string Id, // objectid -> string
    [property: JsonPropertyName("nombre")] string Nombre, // no admin
    [property: JsonPropertyName("email")] string Email, 
    [property: JsonPropertyName("telefono")] string? Telefono 
);