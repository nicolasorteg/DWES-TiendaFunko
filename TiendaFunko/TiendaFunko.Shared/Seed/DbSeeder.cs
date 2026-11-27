using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using TiendaFunko.Shared.Entity;
using TiendaFunko.Shared.Models;

namespace TiendaFunko.Shared.Seed;

/// <summary>
/// Clase encargada del seed incial de datos
/// </summary>
public class DbSeeder {
    
    public static readonly string ProveedorDefaultId = "672f1a8b3c9d4e5f6a7b8c9d"; 
    public static readonly string ProveedorSecundarioId = "672f1a8b3c9d4e5f6a7b8c9e";

    public static async Task SeedAsync(AppDbContext db, AppMongoDbContext dbMongo) {
       
        // categorias
        if (!await db.Categorias.AnyAsync()) {
            
            var fecha = DateTime.UtcNow;
            db.Categorias.AddRange(
                new Categoria { Id = "CatDefault1", Nombre = "Anime", CreatedAt = fecha, IsDeleted = false },
                new Categoria { Id = "CatDefault2", Nombre = "Videojuegos", CreatedAt = fecha, IsDeleted = false },
                new Categoria { Id = "CatDefault3", Nombre = "Famosos", CreatedAt = fecha, IsDeleted = false },
                new Categoria { Id = "CatDefault4", Nombre = "Deportes", CreatedAt = fecha, IsDeleted = false },
                new Categoria { Id = "CatDefault5", Nombre = "Superhéroes", CreatedAt = fecha, IsDeleted = false },
                new Categoria { Id = "CatDefault6", Nombre = "Películas y Series", CreatedAt = fecha, IsDeleted = false }
            );
            await db.SaveChangesAsync();
        }

        // proveedores
        if (!await dbMongo.Proveedores.AnyAsync()) {
            
            var fecha = DateTime.UtcNow;
            dbMongo.Proveedores.AddRange(
                new Proveedor 
                { 
                    Id = ObjectId.Parse(ProveedorDefaultId), 
                    Nombre = "Distribuidores Funko España S.L.", 
                    Email = "contacto@funkodist.es", 
                    Telefono = "+34912345678", 
                    CreatedAt = fecha, 
                    IsDeleted = false 
                },
                new Proveedor 
                { 
                    Id = ObjectId.Parse(ProveedorSecundarioId), 
                    Nombre = "Global Pop Collectibles Ltd.", 
                    Email = "sales@globalpop.com", 
                    Telefono = "+442079460912", 
                    CreatedAt = fecha, 
                    IsDeleted = false 
                }
            );
            await dbMongo.SaveChangesAsync();
        }

        // funkos
        if (!await db.Funkos.AnyAsync()) {
            
            var fecha = DateTime.UtcNow;
            db.Funkos.AddRange(
                new Funko 
                { 
                    Nombre = "Luffy", 
                    Precio = 15.99m, 
                    Stock = 20, 
                    Imagen = "/images/default-image.jpg", 
                    CategoriaId = "CatDefault1", 
                    ProveedorId = ProveedorDefaultId, 
                    CreatedAt = fecha, 
                    IsDeleted = false 
                },
                new Funko 
                { 
                    Nombre = "Geralt de Rivia", 
                    Precio = 18.50m, 
                    Stock = 8, 
                    Imagen = "/images/default-image.jpg", 
                    CategoriaId = "CatDefault2", 
                    ProveedorId = ProveedorDefaultId, 
                    CreatedAt = fecha, 
                    IsDeleted = false 
                },
                new Funko 
                { 
                    Nombre = "Darth Vader", 
                    Precio = 21.00m, 
                    Stock = 5, 
                    Imagen = "/images/default-image.jpg", 
                    CategoriaId = "CatDefault6", 
                    ProveedorId = ProveedorSecundarioId, 
                    CreatedAt = fecha, 
                    IsDeleted = false 
                },
                new Funko 
                { 
                    Nombre = "Sheldon Cooper", 
                    Precio = 15.25m, 
                    Stock = 8, 
                    Imagen = "/images/default-image.jpg", 
                    CategoriaId = "CatDefault3", 
                    ProveedorId = ProveedorDefaultId, 
                    CreatedAt = fecha, 
                    IsDeleted = false 
                },
                new Funko 
                { 
                    Nombre = "Cristiano Ronaldo", 
                    Precio = 18.50m, 
                    Stock = 50, 
                    Imagen = "/images/default-image.jpg", 
                    CategoriaId = "CatDefault4", 
                    ProveedorId = ProveedorDefaultId, 
                    CreatedAt = fecha, 
                    IsDeleted = false 
                },
                new Funko 
                { 
                    Nombre = "SpiderMan", 
                    Precio = 12.25m, 
                    Stock = 5, 
                    Imagen = "/images/default-image.jpg", 
                    CategoriaId = "CatDefault5", 
                    ProveedorId = ProveedorDefaultId, 
                    CreatedAt = fecha, 
                    IsDeleted = false 
                },
                new Funko 
                { 
                    Nombre = "Hulk", 
                    Precio = 13.00m, 
                    Stock = 15, 
                    Imagen = "/images/default-image.jpg", 
                    CategoriaId = "CatDefault5", 
                    ProveedorId = ProveedorSecundarioId, 
                    CreatedAt = fecha, 
                    IsDeleted = false 
                },
                new Funko 
                { 
                    Nombre = "Teemo", 
                    Precio = 21.15m, 
                    Stock = 30, 
                    Imagen = "/images/default-image.jpg", 
                    CategoriaId = "CatDefault2", 
                    ProveedorId = ProveedorSecundarioId, 
                    CreatedAt = fecha, 
                    IsDeleted = false 
                }
            );
            await db.SaveChangesAsync();
        }
    }
}