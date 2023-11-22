using System.ComponentModel.DataAnnotations;

namespace ReservaDeHotel.Models;
public class Cidade
{
    [Key]
    public int? IdCidade {get;set;}
    public string? Nome { get; set;}
    public string? Estado { get; set;}
    public string? País { get; set;}
    public string? Descricao { get; set;}
    public List<Hotel>? Hoteis { get; set;}
}
