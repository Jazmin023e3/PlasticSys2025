using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlasticSYS.Models;

namespace PlasticSYS.Controllers
{
    // La ruta base para el controlador es /api/Usuarios
    [Route("api/[controller]")]
    [ApiController]
    // Asegura que solo los usuarios con el rol "Operador" puedan acceder a este controlador
    // Nota: Es mejor usar [Authorize(Roles = "Administrador")] para CRUD de usuarios
    [Authorize(Roles = "Operador")]
    public class UsuariosController : ControllerBase
    {
        private readonly PlasticSysContext _context;

        public UsuariosController(PlasticSysContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        /// <summary>
        /// Obtiene la lista de usuarios. Permite filtrar por nombre y limitar la cantidad de registros.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios(string nombre, int registros)
        {
            var query = _context.Usuarios.AsQueryable();

            // Filtro por nombre
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                query = query.Where(u => u.Nombre.Contains(nombre));
            }

            // Límite de registros
            if (registros > 0)
            {
                query = query.Take(registros);
            }

            return await query.ToListAsync();
        }

        // GET: api/Usuarios/5
        /// <summary>
        /// Obtiene un usuario por su ID.
        /// El ID se define como long para coincidir con el tipo de clave primaria.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(long id)
        {
            // Nota: FindAsync busca por clave primaria.
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // POST: api/Usuarios
        /// <summary>
        /// Crea un nuevo usuario.
        /// Nota: Este método no hashea la contraseña, lo cual es inseguro. 
        /// El registro seguro debe hacerse a través del AuthController.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.UsuarioId }, usuario);
        }

        // PUT: api/Usuarios/5
        /// <summary>
        /// Actualiza un usuario existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(long id, Usuario usuario)
        {
            // CORRECCIÓN: El parámetro 'id' debe ser del mismo tipo (long) que usuario.UsuarioId

            {
                return BadRequest();
            }

            // Marca la entidad como modificada para que EF Core la actualice.
            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        private bool UsuarioExists(long id)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Usuarios/5
        /// <summary>
        /// Elimina un usuario por su ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(long id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

        /// <summary>
        /// Verifica si un usuario existe por ID.
        /// El ID se define como long para coincidir con el tipo de clave primaria.
        /// </summary>
        