using FluentValidation;
using TiendaFunko.Shared.Dtos.Funkos;

namespace TiendaFunko.Shared.Validators.Funkos;

/// <summary>
/// Validator para la actualización de un Funko.
/// </summary>
public class UpdateFunkoValidator : AbstractValidator<UpdateFunkoDto> {
    
    // constructor que inicializa las reglas de validación
    public UpdateFunkoValidator() {
        
        // se valida solo si se proporciona el nombre
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre del Funko no puede estar vacío si se proporciona")
            .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");


        // se valida solo si se proporciona el precio
        RuleFor(x => x.Precio)
            .GreaterThan(0).WithMessage("El precio debe ser mayor que 0.");

        
        // se valida solo si se proporciona el stock
        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("El stock no puede ser negativo.");

        
        // se valida solo si se proporciona la categoria
        RuleFor(x => x.CategoriaId)
            .NotEmpty().WithMessage("La categoría no puede estar vacía si se proporciona.");

        
        // se valida solo si se proporciona el proveedor
        RuleFor(x => x.ProveedorId)
            .NotEmpty().WithMessage("El proveedor no puede estar vacío si se proporciona.");
        
        // se valida solo si se proporciona la imagen
        When(x => x.Imagen != null, () => {
            RuleFor(x => x.Imagen) 
                .Must(url => Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out _)) 
                .WithMessage("La imagen debe ser una URL o ruta válida.");
        });
    }
}