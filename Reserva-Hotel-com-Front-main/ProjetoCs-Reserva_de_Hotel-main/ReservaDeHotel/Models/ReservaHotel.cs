using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaDeHotel.Models
{
    public class ReservaHotel
    {
        [Key]
        public int? IdReserva { get; set; }
        public string? NomeHospede { get; set; }
        public List<Pagamento>? Pagamento { get; set; }
        public List<EstadiaHotel>? Estadias { get; set;}

    }
}
