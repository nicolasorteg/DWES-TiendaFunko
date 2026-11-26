using FluentValidation;
using TiendaFunko.Shared.Dtos.Funkos;

namespace TiendaFunko.Shared.Validators.Funkos;

/// <summary>
/// Validator para la creación de un Funko.
/// </summary>
public class CreateFunkoValidator : AbstractValidator<CreateFunkoDto> {
    
    // constructor que inicializa las reglas de validación
    public CreateFunkoValidator() {
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre del Funko es obligatorio.")
            .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");
        
        RuleFor(x => x.Precio)
            .NotEmpty().WithMessage("El precio del Funko es obligatorio.")
            .GreaterThan(0).WithMessage("El precio debe ser mayor que 0.");
        
        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("El stock no puede ser negativo.");
        
        RuleFor(x => x.CategoriaId)
            .NotEmpty().WithMessage("La categoría es obligatoria.");
        
        RuleFor(x => x.ProveedorId)
            .NotEmpty().WithMessage("El proveedor es obligatorio.");
        
        RuleFor(x => x.Imagen)
            .Must(url => Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out _))
            .When(x => !string.IsNullOrEmpty(x.Imagen))
            .WithMessage("La imagen debe ser una URL válida");
    }
}