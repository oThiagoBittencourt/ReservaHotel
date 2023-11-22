using ReservaDeHotel.Data;
using ReservaDeHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ReservaDeHotel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private HotelDbContext _dbContext;
        public HotelController(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult> Cadastrar(Hotel hotel)
        {
            if (_dbContext is null || _dbContext.Hotel is null) return NotFound();

            await _dbContext.AddAsync(hotel);
            await _dbContext.SaveChangesAsync();

            return Created("", hotel);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Hotel>>> Listar()
        {
            if (_dbContext is null || _dbContext.Hotel is null) return NotFound();

            return await _dbContext.Hotel.ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Hotel>> Buscar(int id)
        {
            if (_dbContext is null || _dbContext.Hotel is null) return NotFound();

            var hotel = await _dbContext.Hotel.FindAsync(id);

            if (hotel is null) return NotFound();

            return hotel;
        }

        [HttpPut()]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Hotel hotel)
        {
            if (_dbContext is null || _dbContext.Hotel is null) return NotFound();

            _dbContext.Hotel.Update(hotel);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete()]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            if (_dbContext is null || _dbContext.Hotel is null) return NotFound();

            var hotel = await _dbContext.Hotel.FindAsync(id);

            if (hotel is null) return NotFound();

            _dbContext.Remove(hotel);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
