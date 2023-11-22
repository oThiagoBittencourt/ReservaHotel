using ReservaDeHotel.Data;
using ReservaDeHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ReservaDeHotel.Controllers;
[ApiController]
[Route("[controller]")]
public class CidadeController : ControllerBase
{
    private HotelDbContext _dbContext;
    public CidadeController(HotelDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Cidade cidade)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Cidade is null) return NotFound();
        await _dbContext.AddAsync(cidade);
        await _dbContext.SaveChangesAsync();
        return Created("",cidade);
    }
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Cidade>>> Listar()
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Cidade is null) return NotFound();
        return await _dbContext.Cidade.ToListAsync();
    }
    [HttpGet]
    [Route("buscar/{idCidade}")]
    public async Task<ActionResult<Cidade>> Buscar(int idCidade)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Cidade is null) return NotFound();
        var cidadeTemp = await _dbContext.Cidade.FindAsync(idCidade);
        if(cidadeTemp is null) return NotFound();
        return cidadeTemp;
    }
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Cidade cidade)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Cidade is null) return NotFound();
        //var cidadeTemp = await _dbContext.Cidade.FindAsync(cidade.IdCidade);
        //if(cidadeTemp is null) return NotFound();       
        _dbContext.Cidade.Update(cidade);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpDelete()]
    [Route("excluir/{idCidade}")]
    public async Task<ActionResult> Excluir(int idCidade)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Cidade is null) return NotFound();
        var cidadeTemp = await _dbContext.Cidade.FindAsync(idCidade);
        if(cidadeTemp is null) return NotFound();
        _dbContext.Remove(cidadeTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}