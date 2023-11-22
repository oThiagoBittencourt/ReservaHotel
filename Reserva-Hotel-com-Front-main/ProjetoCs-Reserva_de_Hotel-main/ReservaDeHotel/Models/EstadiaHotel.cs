using System;
using System.ComponentModel.DataAnnotations;

namespace ReservaDeHotel.Models
{
    public class EstadiaHotel
    {
        [Key]
        public int? IdEstadia { get; set; }
        public int? QtdQuartos { get; set; }
        public DateTime? DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
        public List<ReservaHotel>? Reservas { get; set;}
    }
}
