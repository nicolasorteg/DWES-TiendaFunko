using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TiendaFunko.Shared.Models;

public class Proveedor {
    
    [BsonId] 
    public ObjectId Id { get; set; }
    
    [BsonElement("nombre")] 
    public string Nombre { get; set; } = string.Empty;
    
    [BsonElement("email")] 
    public string Email { get; set; } = string.Empty; 
    
    [BsonElement("telefono")] 
    public string? Telefono { get; set; }
    
    //metadatos
    [BsonElement("created_at")]
    public DateTime CreatedAt { get; set; }
    [BsonElement("updated_at")]
    public DateTime? UpdatedAt { get; set; }
    [BsonElement("is_deleted")]
    public bool IsDeleted { get; set; }
    [BsonElement("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}