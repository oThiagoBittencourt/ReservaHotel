using System.ComponentModel.DataAnnotations;

namespace ReservaDeHotel.Models;
public class Avaliacao
{
    [Key]
    public int? IdAvaliacao {get;set;}
    public int? HotelId { get; set;}
    public List<Hotel>? Hoteis { get; set;}
    public int? AvaliacaoEstrelas { get; set;}
    public string? Comentario { get; set;}
    public DateTime? DataAvaliacao { get; set;}
}
