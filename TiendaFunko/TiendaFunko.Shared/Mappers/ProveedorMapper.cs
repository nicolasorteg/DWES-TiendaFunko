using TiendaFunko.Shared.Dtos.Proveedores;
using TiendaFunko.Shared.Models;

namespace TiendaFunko.Shared.Mappers;

public static class ProveedorMapper {
    
    // model -> resposedto
    public static ResponseProveedorDto ToResponseDto(this Proveedor proveedor) => new(
        Id: proveedor.Id.ToString(),
        Nombre: proveedor.Nombre,
        Email: proveedor.Email,
        Telefono: proveedor.Telefono
    );
    
    // createdto -> model
    public static Proveedor ToEntity(this CreateProveedorDto proveedor) {
        return new Proveedor() {
            Nombre = proveedor.Nombre,
            Email = proveedor.Email,
            Telefono = proveedor.Telefono,
            CreatedAt = DateTime.UtcNow,
        };
    }
    
    // updatedto -> model
    public static void UpdateEntity(this UpdateProveedorDto dto, Proveedor proveedor) {
        proveedor.Nombre = dto.Nombre;
        proveedor.Email = dto.Email;
        proveedor.Telefono = dto.Telefono;
        proveedor.UpdatedAt = DateTime.UtcNow;
    }
}