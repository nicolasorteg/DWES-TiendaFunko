using CSharpFunctionalExtensions;
using TiendaFunko.Shared.Errors.Common;

namespace TiendaFunko.Shared.Services;

public interface ICrudService<TResponseDto, in TCreateDto, in TUpdateDto, in TKey> where TResponseDto : class {
    Task<Result<IReadOnlyList<TResponseDto>, DomainError>>GetAllAsync();
    Task<Result<TResponseDto, DomainError>> GetByIdAsync(TKey id);
    Task<Result<TResponseDto, DomainError>> GetByNameAsync(string id);
    Task<Result<TResponseDto, DomainError>> AddAsync(TCreateDto entity);
    Task<Result<TResponseDto, DomainError>> UpdateAsync(TKey id, TUpdateDto entity);
    Task<UnitResult<DomainError>> DeleteAsync(TKey id);
}