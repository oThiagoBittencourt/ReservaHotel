using System.ComponentModel.DataAnnotations;

namespace ReservaDeHotel.Models;
public class Pagamento
{
    [Key]
    public int? IdPagamento {get;set;}
    public int? ReservaId { get; set; }
    public ReservaHotel? Reserva { get; set; }
    public string? MetodoPagamento { get; set;}
    public decimal? Valor { get; set;} 
    public DateTime? DataPagamento { get; set;}
}
