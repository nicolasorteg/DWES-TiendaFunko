using System.ComponentModel.DataAnnotations;
using TiendaFunko.Shared.Validators.Attributes;

namespace TiendaFunko.Shared.Models;

public class Categoria {

    [Key]
    [YouTubeId] // id estilo yt
    public string Id { get; set; } = null!;

    [Required] 
    [MaxLength(100)] 
    public string Nombre { get; set; } = string.Empty;

    // metadatos
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }

    public ICollection<Funko> Funkos { get; set; } = new List<Funko>(); // lista para bidireccionalidad
}