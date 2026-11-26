using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace TiendaFunko.Shared.IdGenerators;

/// <summary>
/// Genera los ID de 11 caracteres siguiendo el formato de YouTube (Base64url)
/// </summary>
public class YouTubeIdValueGenerator : ValueGenerator<string> {
    
    // caracteres válidos para base64url
    private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_";

    // random.shared es thread-safe
    public override string Next(EntityEntry entry) =>
        new string(Enumerable.Range(0, 11).Select(_ => Chars[Random.Shared.Next(64)]).ToArray());

    // indica que no genera valores temporales
    public override bool GeneratesTemporaryValues => false;
}