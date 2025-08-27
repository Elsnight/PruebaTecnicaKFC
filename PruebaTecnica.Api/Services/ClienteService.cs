using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Api.Data;
using PruebaTecnica.Api.Domain;
using PruebaTecnica.Api.Dtos;


namespace PruebaTecnica.Api.Services;


public class ClienteService : IClienteService
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;


    public ClienteService(AppDbContext db, IMapper mapper)
    { _db = db; _mapper = mapper; }


    public async Task<(IReadOnlyList<ClienteDto> items, int total)> GetAsync(int page, int size, CancellationToken ct)
    {
        var query = _db.Clientes.AsNoTracking().OrderBy(c => c.Id);
        var total = await query.CountAsync(ct);
        var items = await query.Skip((page - 1) * size).Take(size)
        .ProjectTo<ClienteDto>(_mapper.ConfigurationProvider)
        .ToListAsync(ct);
        return (items, total);
    }


    public async Task<ClienteDto?> GetByIdAsync(int id, CancellationToken ct)
    {
        var entity = await _db.Clientes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, ct);
        return entity is null ? null : _mapper.Map<ClienteDto>(entity);
    }


    public async Task<ClienteDto> CreateAsync(ClienteCreateDto dto, CancellationToken ct)
    {
        var entity = _mapper.Map<Cliente>(dto);
        _db.Clientes.Add(entity);
        await _db.SaveChangesAsync(ct);
        return _mapper.Map<ClienteDto>(entity);
    }


    public async Task<bool> UpdateAsync(int id, ClienteUpdateDto dto, CancellationToken ct)
    {
        var entity = await _db.Clientes.FindAsync(new object?[] { id }, ct);
        if (entity is null) return false;
        _mapper.Map(dto, entity);
        await _db.SaveChangesAsync(ct);
        return true;
    }


    public async Task<bool> DeleteAsync(int id, CancellationToken ct)
    {
        var entity = await _db.Clientes.FindAsync(new object?[] { id }, ct);
        if (entity is null) return false;
        _db.Clientes.Remove(entity);
        await _db.SaveChangesAsync(ct);
        return true;
    }
}