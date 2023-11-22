using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservaDeHotel.Data;
using ReservaDeHotel.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservaDeHotel.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private HotelDbContext _dbContext;

        public ClienteController(HotelDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] Cliente cliente)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Cliente is null) return NotFound();

            await _dbContext.Cliente.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();

            return Created("", cliente);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Cliente>>> Listar()
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Cliente is null) return NotFound();

            var clientes = await _dbContext.Cliente.ToListAsync();
            return Ok(clientes);
        }

        [HttpGet]
        [Route("buscar/{idCliente}")]
        public async Task<ActionResult<Cliente>> Buscar(int idCliente)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Cliente is null) return NotFound();

            var ClienteTemp = await _dbContext.Cliente.FindAsync(idCliente);
            if (ClienteTemp is null) return NotFound();

            return ClienteTemp;
        }

        [HttpPut()]
        [Route("alterar")]
        public async Task<IActionResult> Alterar([FromBody] Cliente cliente)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Cliente is null) return NotFound();

            _dbContext.Cliente.Update(cliente);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete()]
        [Route("excluir/{idCliente}")]
        public async Task<IActionResult> Excluir(int idCliente)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Cliente is null) return NotFound();

            var ClienteTemp = await _dbContext.Cliente.FindAsync(idCliente);
            if (ClienteTemp is null) return NotFound();

            _dbContext.Cliente.Remove(ClienteTemp);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }

