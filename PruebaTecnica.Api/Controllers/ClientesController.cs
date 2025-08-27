using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Api.Dtos;
using PruebaTecnica.Api.Services;


namespace PruebaTecnica.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ClientesController(IClienteService service) : ControllerBase
{
    private readonly IClienteService _service = service;


    [HttpGet]
    public async Task<ActionResult> Get(int page = 1, int size = 20, CancellationToken ct = default)
    {
        if (page <= 0 || size <= 0) return BadRequest("page/size inválidos");
        var (items, total) = await _service.GetAsync(page, size, ct);
        Response.Headers["X-Total-Count"] = total.ToString();
        return Ok(items);
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<ClienteDto>> GetById(int id, CancellationToken ct)
    {
        var cli = await _service.GetByIdAsync(id, ct);
        return cli is null ? NotFound() : Ok(cli);
    }


    [HttpPost]
    public async Task<ActionResult<ClienteDto>> Create([FromBody] ClienteCreateDto dto, CancellationToken ct)
    {
        var created = await _service.CreateAsync(dto, ct);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ClienteUpdateDto dto, CancellationToken ct)
    {
        var ok = await _service.UpdateAsync(id, dto, ct);
        return ok ? NoContent() : NotFound();
    }


    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var ok = await _service.DeleteAsync(id, ct);
        return ok ? NoContent() : NotFound();
    }
}