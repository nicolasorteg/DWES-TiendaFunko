using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TiendaFunko.Shared.Dtos.Categorias;

public record UpdateCategoriaDto( 
    [property: JsonPropertyName("nombre")] 
    [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")] 
    [MaxLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")] 
    string Nombre
);