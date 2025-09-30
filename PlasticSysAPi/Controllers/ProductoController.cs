using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlasticSYS.Models;

namespace PlasticSYS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // 1. Dejamos Authorize para proteger POST, PUT y DELETE.
    [Authorize(Roles = "Operador")]
    public class ProductosController : ControllerBase
    {
        private readonly PlasticSysContext _context;

        public ProductosController(PlasticSysContext context)
        {
            _context = context;
        }

        // ===============================================
        // GET: api/Productos (Público - No requiere Login)
        // ===============================================
        [HttpGet]
        [AllowAnonymous] // <--- AGREGAMOS ESTO
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos(string nombre, int registros)
        {
            var query = _context.Productos.AsQueryable();
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                query = query.Where(p => p.Nombre.Contains(nombre));
            }
            if (registros > 0)
            {
                query = query.Take(registros);
            }
            // Agregamos Include para evitar errores si necesitas datos de otras tablas relacionadas
            return await query.Include(p => p.Marca).ToListAsync();
        }

        // ===============================================
        // GET: api/Productos/5 (Público - No requiere Login)
        // ===============================================
        [HttpGet("{id}")]
        [AllowAnonymous] // <--- AGREGAMOS ESTO
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            // Agregamos Include para evitar errores si necesitas datos de otras tablas relacionadas
            var producto = await _context.Productos
                .Include(p => p.Marca)
                .FirstOrDefaultAsync(p => p.ProductoId == id); // Usamos FirstOrDefaultAsync para incluir Marca

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        // ===============================================
        // POST: api/Productos (Privado - Requiere Token y Rol "Operador")
        // ===============================================
        [HttpPost]
        // No necesita [Authorize] aquí porque ya está arriba
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducto", new { id = producto.ProductoId }, producto);
        }

        // ... (PUT y DELETE siguen siendo privados por el [Authorize] a nivel de clase)

        // ... (resto del código)
    }
}