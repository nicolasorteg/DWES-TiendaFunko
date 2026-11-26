using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TiendaFunko.Shared.Dtos.Funkos;

public record CreateFunkoDto( 
    
    [property: JsonPropertyName("nombre")] 
    [Required(ErrorMessage = "El nombre es obligatorio.")] 
    [MaxLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")] 
    string Nombre, 
    
    [property: JsonPropertyName("precio")] 
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")] 
    decimal Precio, 
    
    [property: JsonPropertyName("stock")] 
    [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
    int Stock, 
    
    [property: JsonPropertyName("categoria_id")] 
    [Required(ErrorMessage = "La categoría es obligatoria.")] 
    string CategoriaId, 
    
    [property: JsonPropertyName("proveedor_id")] 
    [Required(ErrorMessage = "El proveedor es obligatorio.")] 
    string ProveedorId, 
    
    [property: JsonPropertyName("imagen")] 
    string? Imagen = null 
);