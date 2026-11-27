namespace TiendaFunko.Shared.Configuration;

// config de la caché
public class CacheOptions {
    
    public const string SectionName = "Cache";
    
    // propiedades de configuración 
    public int CacheSize { get; set; } = 1000; 
    public int DefaultExpirationMinutes { get; set; } = 30; 
    public int SlidingExpirationMinutes { get; set; } = 10; 
    
    public TimeSpan DefaultExpiration => TimeSpan.FromMinutes(DefaultExpirationMinutes);
    public TimeSpan SlidingExpiration => TimeSpan.FromMinutes(SlidingExpirationMinutes);
}