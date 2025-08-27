using AutoMapper;
using PruebaTecnica.Api.Domain;
using PruebaTecnica.Api.Dtos;


namespace PruebaTecnica.Api.Profiles;


public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<Cliente, ClienteDto>();
        CreateMap<ClienteCreateDto, Cliente>();
        CreateMap<ClienteUpdateDto, Cliente>();
    }
}