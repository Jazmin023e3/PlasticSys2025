using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlasticSYS.Models;
using PlasticSysAPi.DTOS;
using PlasticSysAPi.Interfaces;

namespace PlasticSYS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly IVentaService _service;

        // 2.Inyeccion de dependencia del servicio
        public VentasController(IVentaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
           => Ok(await _service.GetAllAsync());

        [HttpGet("{Id_venta:int}")]
        public async Task<IActionResult> GetById(int Id_venta)
        {
            var item = await _service.GetByIdAsync(Id_venta);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VentaCrearDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { Id_venta = created.VentaId }, created);
        }

        [HttpPut("{Id_venta}")]
        public async Task<IActionResult> Update(int Id_venta, [FromBody] VentaActualizarDTO dto)
        {
            var ok = await _service.UpdateAsync(Id_venta, dto);
            return ok ? NoContent() : NotFound();
        }

        [HttpDelete("{Id_venta:int}")]
        public async Task<IActionResult> Delete(int Id_venta)
        {
            var ok = await _service.DeleteAsync(Id_venta);
            return ok ? NoContent() : NotFound();
        }
    }
}