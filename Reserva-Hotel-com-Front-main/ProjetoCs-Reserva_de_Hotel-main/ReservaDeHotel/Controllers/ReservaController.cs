using ReservaDeHotel.Data;
using ReservaDeHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservaDeHotel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservaController : ControllerBase
    {
        private HotelDbContext _dbContext;
        public ReservaController(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult> Cadastrar(ReservaHotel reserva)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.ReservaHotel is null) return NotFound();
            await _dbContext.AddAsync(reserva);
            await _dbContext.SaveChangesAsync();
            return Created("", reserva);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<ReservaHotel>>> Listar()
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.ReservaHotel is null) return NotFound();
            return await _dbContext.ReservaHotel.ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{idReserva}")]
        public async Task<ActionResult<ReservaHotel>> Buscar(int idReserva)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.ReservaHotel is null) return NotFound();
            var reserva = await _dbContext.ReservaHotel.FindAsync(idReserva);
            if (reserva is null) return NotFound();
            return reserva;
        }

        [HttpPut()]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(ReservaHotel reserva)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.ReservaHotel is null) return NotFound();
            //var ReservaTemp = await _dbContext.Reserva.FindAsync(Reserva.IdReserva);
            //if(ReservaTemp is null) return NotFound();  
            _dbContext.ReservaHotel.Update(reserva);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete()]
        [Route("excluir/{idReserva}")]
        public async Task<ActionResult> Excluir(int idReserva)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.ReservaHotel is null) return NotFound();
            var reserva = await _dbContext.ReservaHotel.FindAsync(idReserva);
            if (reserva is null) return NotFound();
            _dbContext.ReservaHotel.Remove(reserva);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}