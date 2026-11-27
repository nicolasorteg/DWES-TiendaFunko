using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TiendaFunko.Shared.Configuration;
using TiendaFunko.Shared.Repositories;
using TiendaFunko.Shared.Repositories.Categorias;
using TiendaFunko.Shared.Repositories.Proveedores;
using TiendaFunko.Shared.Services.Cache;
using TiendaFunko.Shared.Services.Funkos;

namespace TiendaFunko.Shared.Infrastructures;

public static class ServicesConfig {

    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration) {
        // caché en memoria
        services.AddMemoryCache();
        services.Configure<CacheOptions>(configuration.GetSection(CacheOptions.SectionName));
        services.AddScoped<ICacheService, MemoryCacheService>();

        // repositorios
        services.AddScoped<IFunkosRepository, FunkosRepository>();
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped<IProveedorRepository, ProveedorRepository>();

        // servicios
        services.AddScoped<IFunkoService, FunkoService>();

        return services;
    }
}