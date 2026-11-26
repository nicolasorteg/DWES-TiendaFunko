using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaFunko.Shared.Models;

public class Funko {
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;
    
    // el required no sirve de nada puesto que al ser decimal la columna ya es NOT NULL
    // el precio no negativo se garantiza en AppDbContext
    [Range(0.01, 999999.99, ErrorMessage = "El precio debe estar entre 0.01 y 9999.99")]
    public decimal Precio { get; set; }
    
    [Required]
    public int Stock { get; set; }
    
    public string? Imagen { get; set; }
    
    [Required]
    public string CategoriaId { get; set; } = string.Empty;

    public Categoria Categoria { get; set; } = null!;
    
    [Required]
    public string ProveedorId { get; set; } = string.Empty;
    
    // metadatos
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}