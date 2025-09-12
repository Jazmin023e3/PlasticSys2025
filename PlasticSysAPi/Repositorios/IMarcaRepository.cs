using Microsoft.EntityFrameworkCore;
using PlasticSYS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlasticSysAPI.Repositorios
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly PlasticSysContext _context;

        public MarcaRepository(PlasticSysContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Marca>> GetMarcasAsync()
        {
            return await _context.Marcas.ToListAsync();
        }
        // Agrega las implementaciones de los otros métodos de la interfaz
    }
}
