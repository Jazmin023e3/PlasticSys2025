using Microsoft.AspNetCore.Mvc;
using PlasticSYS.Models.DTOs;
using PlasticSysAPi.DTOS;
using PlasticSysAPi.Interfaces;

// 1. Marcar como controlador de API
[ApiController]
// 2. Definir la ruta base para este controlador
[Route("api/[controller]")]
public class ClienteController : ControllerBase // Cambiar a ControllerBase para APIs
{
    private readonly IClienteService _service;
    public ClienteController(IClienteService service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
       => Ok(await _service.GetAllAsync());
    [HttpGet("{Id_Cliente:int}")]
    public async Task<IActionResult> GetById(int Id_Cliente)
    {
        var item = await _service.GetByIdAsync(Id_Cliente);
        return item is null ? NotFound() : Ok(item);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ClienteCreateDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { Id_Cliente = created.ClienteId}, created);
    }
    [HttpPut("{Id_Cliente}")]
    public async Task<IActionResult> Update(int Id_Cliente, [FromBody] ClienteActualizarDTO dto)
    {
        var ok = await _service.UpdateAsync(Id_Cliente, dto);
        return ok ? NoContent() : NotFound();
    }
    [HttpDelete("{Id_Cliente:int}")]
    public async Task<IActionResult> Delete(int Id_Cliente)
    {
        var ok = await _service.DeleteAsync(Id_Cliente);
        return ok ? NoContent() : NotFound();
    }
}
