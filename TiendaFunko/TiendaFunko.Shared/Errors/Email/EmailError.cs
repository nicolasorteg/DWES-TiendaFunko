using TiendaFunko.Shared.Errors.Common;

namespace TiendaFunko.Shared.Errors.Email;

public static class EmailError
{
    // Record de error para fallos en el envío de correo
    public sealed record SendFailed(string Mensaje)
        : DomainError($"Error al enviar el correo electrónico: {Mensaje}");
}

public static class EmailErrors
{
    public static DomainError SendFailed(string mensaje) =>
        new EmailError.SendFailed(mensaje);
}