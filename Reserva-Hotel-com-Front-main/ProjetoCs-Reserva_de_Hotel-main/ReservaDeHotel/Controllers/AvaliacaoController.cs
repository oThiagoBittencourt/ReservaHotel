using ReservaDeHotel.Data;
using ReservaDeHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ReservaDeHotel.Controllers;
[ApiController]
[Route("[controller]")]

public class AvaliacaoController : ControllerBase
{
    private HotelDbContext _dbContext;

    public AvaliacaoController(HotelDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Avaliacao avaliacao)
    {
        if (_dbContext is null || _dbContext.Avaliacao is null) return NotFound();

        await _dbContext.AddAsync(avaliacao);
        await _dbContext.SaveChangesAsync();

        return Created("", avaliacao);
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Avaliacao>>> Listar()
    {
        if (_dbContext is null || _dbContext.Avaliacao is null) return NotFound();

        return await _dbContext.Avaliacao.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Avaliacao>> Buscar(int id)
    {
        if (_dbContext is null || _dbContext.Avaliacao is null) return NotFound();

        var avaliacao = await _dbContext.Avaliacao.FindAsync(id);

        if (avaliacao is null) return NotFound();

        return avaliacao;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Avaliacao avaliacao)
    {
        if (_dbContext is null || _dbContext.Avaliacao is null) return NotFound();

        _dbContext.Avaliacao.Update(avaliacao);
        await _dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        if (_dbContext is null || _dbContext.Avaliacao is null) return NotFound();

        var avaliacao = await _dbContext.Avaliacao.FindAsync(id);

        if (avaliacao is null) return NotFound();

        _dbContext.Remove(avaliacao);
        await _dbContext.SaveChangesAsync();

        return Ok();
    }
}
