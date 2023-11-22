using ReservaDeHotel.Data;
using ReservaDeHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ReservaDeHotel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComodidadeController : ControllerBase
    {
        private HotelDbContext _dbContext;

        public ComodidadeController(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult> Cadastrar(Comodidade comodidade)
        {
            if (_dbContext is null || _dbContext.Comodidade is null) return NotFound();

            await _dbContext.AddAsync(comodidade);
            await _dbContext.SaveChangesAsync();

            return Created("", comodidade);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Comodidade>>> Listar()
        {
            if (_dbContext is null || _dbContext.Comodidade is null) return NotFound();

            return await _dbContext.Comodidade.ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Comodidade>> Buscar(int id)
        {
            if (_dbContext is null || _dbContext.Comodidade is null) return NotFound();

            var Comodidade = await _dbContext.Comodidade.FindAsync(id);

            if (Comodidade is null) return NotFound();

            return Comodidade;
        }

        [HttpPut()]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Comodidade comodidade)
        {
            if (_dbContext is null || _dbContext.Comodidade is null) return NotFound();

            _dbContext.Comodidade.Update(comodidade);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete()]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            if (_dbContext is null || _dbContext.Comodidade is null) return NotFound();

            var Comodidade = await _dbContext.Comodidade.FindAsync(id);

            if (Comodidade is null) return NotFound();

            _dbContext.Remove(Comodidade);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
