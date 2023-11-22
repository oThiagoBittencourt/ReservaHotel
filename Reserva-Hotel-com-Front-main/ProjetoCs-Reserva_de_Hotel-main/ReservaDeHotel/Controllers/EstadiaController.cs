using ReservaDeHotel.Data;
using ReservaDeHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ReservaDeHotel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstadiaController : ControllerBase
    {
        private HotelDbContext _dbContext;
        public EstadiaController(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult> Cadastrar(EstadiaHotel estadia)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.EstadiaHotel is null) return NotFound();
            await _dbContext.AddAsync(estadia);
            await _dbContext.SaveChangesAsync();
            return Created("", estadia);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<EstadiaHotel>>> Listar()
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.EstadiaHotel is null) return NotFound();
            return await _dbContext.EstadiaHotel.ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{idEstadia}")]
        public async Task<ActionResult<EstadiaHotel>> Buscar(int idEstadia)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.EstadiaHotel is null) return NotFound();
            var EstadiaTemp = await _dbContext.EstadiaHotel.FindAsync(idEstadia);
            if (EstadiaTemp is null) return NotFound();
            return EstadiaTemp;
        }

        [HttpPut()]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(EstadiaHotel estadia)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.EstadiaHotel is null) return NotFound();
            //var EstadiaTemp = await _dbContext.Estadia.FindAsync(Estadia.IdEstadia);
            //if(EstadiaTemp is null) return NotFound();    
            _dbContext.EstadiaHotel.Update(estadia);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete()]
        [Route("excluir/{idEstadia}")]
        public async Task<ActionResult> Excluir(int idEstadia)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.EstadiaHotel is null) return NotFound();
            var estadia = await _dbContext.EstadiaHotel.FindAsync(idEstadia);
            if (estadia is null) return NotFound();
            _dbContext.EstadiaHotel.Remove(estadia);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}