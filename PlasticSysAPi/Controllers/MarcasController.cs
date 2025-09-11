using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlasticSysAPI.DTOS; // ¡Importante! Asegúrate de tener esta línea

namespace PlasticSysAPI.DTOS
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Operador")]
    public class MarcasApiController : ControllerBase
    {
        private readonly PlasticSysContext _context;
        public PlasticSysContext Context => _context;

        public MarcasApiController(PlasticSysContext context)
        {
            _context = context;
        }

        // GET: api/MarcasApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarcaDto>>> GetMarcas()
        {
            // Se usa el DTO para la respuesta.
            return await Context.Marcas
                .Select(m => new MarcaDto { MarcaId = m.MarcaId, Nombre = m.Nombre })
                .ToListAsync();
        }

        // GET: api/MarcasApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarcaDto>> GetMarca(int id)
        {
            var marca = await Context.Marcas.FindAsync(id);

            if (marca == null)
            {
                return NotFound();
            }

            // Se mapea la entidad a un DTO antes de devolverla.
            var marcaDto = new MarcaDto { MarcaId = marca.MarcaId, Nombre = marca.Nombre };

            return marcaDto;
        }

        // PUT: api/MarcasApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarca(int id, MarcaActualizarDto marcaDto)
        {
            var marca = await Context.Marcas.FindAsync(id);
            if (marca == null)
            {
                return NotFound();
            }

            // Se actualiza la entidad con los datos del DTO.
            marca.Nombre = marcaDto.Nombre;

            Context.Entry(marca).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MarcasApi
        [HttpPost]
        public async Task<ActionResult<MarcaDto>> PostMarca(MarcaCrearDto marcaDto)
        {
            // Se crea una nueva entidad a partir del DTO.
            var marca = new Marca { Nombre = marcaDto.Nombre };

            Context.Marcas.Add(marca);
            await Context.SaveChangesAsync();

            // Se mapea la nueva entidad a un DTO para la respuesta.
            var nuevaMarcaDto = new MarcaDto { MarcaId = marca.MarcaId, Nombre = marca.Nombre };

            return CreatedAtAction("GetMarca", new { id = nuevaMarcaDto.MarcaId }, nuevaMarcaDto);
        }

        // DELETE: api/MarcasApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarca(int id)
        {
            var marca = await Context.Marcas.FindAsync(id);
            if (marca == null)
            {
                return NotFound();
            }

            Context.Marcas.Remove(marca);
            await Context.SaveChangesAsync();

            return NoContent();
        }

        private bool MarcaExists(int id)
        {
            return Context.Marcas.Any(e => e.MarcaId == id);
        }
    }
}