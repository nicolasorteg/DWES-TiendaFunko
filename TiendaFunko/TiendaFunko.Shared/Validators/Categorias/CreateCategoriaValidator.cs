using FluentValidation;
using TiendaFunko.Shared.Dtos.Categorias;

namespace TiendaFunko.Shared.Validators.Categorias;

/// <summary>
/// Validador para la creación de una categoría.
/// </summary>
public class CreateCategoriaValidator : AbstractValidator<CreateCategoriaDto> {
    
    // constructor que inicializa las reglas de validación
    public CreateCategoriaValidator() {
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre de la categoría es obligatorio.")
            .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");
    }
}