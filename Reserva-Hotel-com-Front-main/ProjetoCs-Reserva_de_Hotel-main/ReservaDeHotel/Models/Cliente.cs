using System.ComponentModel.DataAnnotations;

namespace ReservaDeHotel.Models;
public class Cliente
{
    [Key]
    public int? IdCliente {get;set;}
    public string? Nome { get; set;}
    public int? NumeroTelefone { get; set;}
    public string? Email { get; set;}
    public string? Login { get; set;}
    public string? Senha { get; set;}
}
