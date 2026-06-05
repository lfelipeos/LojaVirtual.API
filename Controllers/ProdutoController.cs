using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LojaVirtual.API.Data;
using LojaVirtual.API.Models;

namespace LojaVirtual.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> ObterTodos()
    {
        var produtos = await _context.Set<Produto>().ToListAsync();
        return Ok(produtos);
    }

    [HttpPost]
    public async Task<ActionResult<Produto>> Criar([FromBody] Produto produto)
    {
        _context.Set<Produto>().Add(produto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(ObterTodos), new { id = produto.Id }, produto);
    }
}