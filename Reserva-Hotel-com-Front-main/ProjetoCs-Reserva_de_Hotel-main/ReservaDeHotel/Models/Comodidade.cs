using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaDeHotel.Models;
public class Comodidade
{
    [Key]
    public int? IDComodidade { get; set; }
    public int? NumeroDoQuarto { get; set; } 
    public string? TipoDeQuarto { get; set; }
    public decimal? PrecoPorNoite { get; set; }
    public string? Descricao { get; set; }
    public bool? Disponibilidade { get; set; }
 
}
