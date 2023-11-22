using ReservaDeHotel.Data;
using ReservaDeHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ReservaDeHotel.Controllers;
[ApiController]
[Route("[controller]")]
public class PagamentoController : ControllerBase
{
    private HotelDbContext _dbContext;
    public PagamentoController(HotelDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Pagamento pagamento)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Pagamento is null) return NotFound();
        await _dbContext.AddAsync(pagamento);
        await _dbContext.SaveChangesAsync();
        return Created("",pagamento);
    }
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Pagamento>>> Listar()
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Pagamento is null) return NotFound();
        return await _dbContext.Pagamento.ToListAsync();
    }
    [HttpGet]
    [Route("buscar/{idPagamento}")]
    public async Task<ActionResult<Pagamento>> Buscar(int idPagamento)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Pagamento is null) return NotFound();
        var PagamentoTemp = await _dbContext.Pagamento.FindAsync(idPagamento);
        if(PagamentoTemp is null) return NotFound();
        return PagamentoTemp;
    }
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Pagamento pagamento)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Pagamento is null) return NotFound();
        //var PagamentoTemp = await _dbContext.Pagamento.FindAsync(Pagamento.IdPagamento);
        //if(PagamentoTemp is null) return NotFound();       
        _dbContext.Pagamento.Update(pagamento);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpDelete()]
    [Route("excluir/{idPagamento}")]
    public async Task<ActionResult> Excluir(int idPagamento)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Pagamento is null) return NotFound();
        var PagamentoTemp = await _dbContext.Pagamento.FindAsync(idPagamento);
        if(PagamentoTemp is null) return NotFound();
        _dbContext.Remove(PagamentoTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}