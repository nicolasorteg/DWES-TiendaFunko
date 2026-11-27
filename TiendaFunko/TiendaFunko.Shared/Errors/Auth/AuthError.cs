using TiendaFunko.Shared.Errors.Common;

namespace TiendaFunko.Shared.Errors.Auth;

public static class AuthError {
    
    public sealed record Unauthorized(string Mensaje = "Credenciales inválidas") : 
        DomainError(Mensaje); 
    
    public sealed record Conflict(string Email) : 
        DomainError($"El usuario con email '{Email}' ya existe."); 
    
    public sealed record UserNotFound(long Id) :
        DomainError($"No se ha encontrado el usuario con ID '{Id}'."); 
    
    public sealed record CreationFailed(string Detalle) : 
        DomainError($"Error al crear el usuario: {Detalle}");
}