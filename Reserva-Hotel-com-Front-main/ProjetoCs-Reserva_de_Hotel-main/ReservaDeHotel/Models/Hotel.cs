using System.ComponentModel.DataAnnotations;

namespace ReservaDeHotel.Models;
public class Hotel
{
    [Key]
    public int IDHotel { get; set; }
    public string? Nome { get; set; }
    public string? Endereco { get; set; }
    public List<Avaliacao>? ListaAvaliacoes { get; set;}
    public int? ComodidadeId { get; set; }
    public Comodidade? Comodidade {get;set;}
    public string? Descricao { get; set; }
    public string? ListaDeQuartos { get; set; }
    public int NumeroTotalDeQuartos { get; set; }
    public int NumeroDeQuartosDisponiveis { get; set; }
    public List<Cidade>? Cidades { get; set;}
    public List<Dono>? Donos { get; set;}
}
