using System.ComponentModel.DataAnnotations;


namespace PruebaTecnica.Api.Domain;


public class Cliente
{
    public int Id { get; set; }


    [Required, MaxLength(120)]
    public string Nombre { get; set; } = null!;


    [EmailAddress, MaxLength(160)]
    public string? Email { get; set; }


}