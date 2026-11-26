using FluentValidation;
using TiendaFunko.Shared.Dtos.Categorias;

namespace TiendaFunko.Shared.Validators.Categorias;

/// <summary>
/// Validador para la actualización de una categoría.
/// </summary>  
public class UpdateCategoriaValidator : AbstractValidator<UpdateCategoriaDto> {
    
    // constructor que inicializa las reglas de validación
    public UpdateCategoriaValidator() {
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre de la categoría es obligatorio.")
            .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");
    }
}