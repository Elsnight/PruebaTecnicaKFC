using FluentValidation;
using PruebaTecnica.Api.Dtos;


namespace PruebaTecnica.Api.Validators;


public class ClienteCreateDtoValidator : AbstractValidator<ClienteCreateDto>
{
    public ClienteCreateDtoValidator()
    {
        RuleFor(x => x.Nombre).NotEmpty().MaximumLength(120);
        RuleFor(x => x.Email).EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.Email));
    }
}


public class ClienteUpdateDtoValidator : AbstractValidator<ClienteUpdateDto>
{
    public ClienteUpdateDtoValidator()
    {
        RuleFor(x => x.Nombre).NotEmpty().MaximumLength(120);
        RuleFor(x => x.Email).EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.Email));
    }
}