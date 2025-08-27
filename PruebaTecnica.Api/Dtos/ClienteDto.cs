namespace PruebaTecnica.Api.Dtos;


public record ClienteCreateDto(string Nombre, string? Email);
public record ClienteUpdateDto(string Nombre, string? Email);
public record ClienteDto(int Id, string Nombre, string? Email);