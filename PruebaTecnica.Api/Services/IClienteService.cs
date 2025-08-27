using PruebaTecnica.Api.Dtos;
using System.Threading;

namespace PruebaTecnica.Api.Services;

public interface IClienteService
{
    Task<(IReadOnlyList<ClienteDto> items, int total)> GetAsync(int page, int size, CancellationToken ct);
    Task<ClienteDto?> GetByIdAsync(int id, CancellationToken ct);
    Task<ClienteDto> CreateAsync(ClienteCreateDto dto, CancellationToken ct);
    Task<bool> UpdateAsync(int id, ClienteUpdateDto dto, CancellationToken ct);
    Task<bool> DeleteAsync(int id, CancellationToken ct);
}
