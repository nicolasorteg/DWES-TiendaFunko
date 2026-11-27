using TiendaFunko.Shared.Dtos.Funkos;

namespace TiendaFunko.Shared.Services.Funkos;

public interface IFunkoService : ICrudService<ResponseFunkoDto, CreateFunkoDto, UpdateFunkoDto, long> { }