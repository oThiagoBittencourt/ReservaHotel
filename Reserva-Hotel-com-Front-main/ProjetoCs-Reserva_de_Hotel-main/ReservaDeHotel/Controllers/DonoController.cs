using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservaDeHotel.Data;
using ReservaDeHotel.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservaDeHotel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DonoController : ControllerBase
    {
        private HotelDbContext _dbContext;

        public DonoController(HotelDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] Dono dono)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Dono is null) return NotFound();

            await _dbContext.Dono.AddAsync(dono);
            await _dbContext.SaveChangesAsync();

            return Created("", dono);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Dono>>> Listar()
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Dono is null) return NotFound();

            var Donos = await _dbContext.Dono.ToListAsync();
            return Ok(Donos);
        }

        [HttpGet]
        [Route("buscar/{idDono}")]
        public async Task<ActionResult<Dono>> Buscar(int idDono)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Dono is null) return NotFound();

            var DonoTemp = await _dbContext.Dono.FindAsync(idDono);
            if (DonoTemp is null) return NotFound();

            return DonoTemp;
        }

        [HttpPut()]
        [Route("alterar")]
        public async Task<IActionResult> Alterar([FromBody] Dono dono)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Dono is null) return NotFound();

            _dbContext.Dono.Update(dono);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete()]
        [Route("excluir/{idDono}")]
        public async Task<IActionResult> Excluir(int idDono)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Dono is null) return NotFound();

            var DonoTemp = await _dbContext.Dono.FindAsync(idDono);
            if (DonoTemp is null) return NotFound();

            _dbContext.Dono.Remove(DonoTemp);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
