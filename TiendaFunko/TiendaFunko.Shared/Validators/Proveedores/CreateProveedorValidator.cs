using FluentValidation;
using TiendaFunko.Shared.Dtos.Proveedores;

namespace TiendaFunko.Shared.Validators.Proveedores;

/// <summary>
/// Validator para la creación de un Proveedor.
/// </summary>
public class CreateProveedorValidator : AbstractValidator<CreateProveedorDto> {

    // constructor que inicializa las reglas de validación
    public CreateProveedorValidator() {
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre del proveedor es obligatorio.")
            .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("El email del proveedor es obligatorio.")
            .EmailAddress().WithMessage("El formato del email no es válido.")
            .MaximumLength(150).WithMessage("El email no puede superar los 150 caracteres.");

        RuleFor(x => x.Telefono)
            .Matches(@"^[+]?[\d\s\-()]{7,20}$")
            .When(x => !string.IsNullOrEmpty(x.Telefono))
            .WithMessage("El teléfono debe tener un formato válido (entre 7 y 20 caracteres, solo dígitos, espacios, +, -, paréntesis).");
    }
}