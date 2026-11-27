using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TiendaFunko.Shared.Validators.Funkos;

namespace TiendaFunko.Shared.Infrastructures;

public static class ValidationConfig {

    public static IServiceCollection AddValidation(this IServiceCollection services) {
        // registra todos los IValidator<T> del ensamblado Shared
        services.AddValidatorsFromAssemblyContaining<CreateFunkoValidator>();
        return services;
    }
}