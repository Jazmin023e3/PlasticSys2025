using Microsoft.EntityFrameworkCore;
using PlasticSYS.Models;
using PlasticSysAPi.Context;
using PlasticSysAPI.Interfaces;

namespace PlasticSysAPi.Repositorios
{
    public class ClienteRepository :IClienteRepository
    {
        private readonly AppDbContext _context;
        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Cliente>> GetAllAsync()
            => await _context.Clientes.AsNoTracking().ToListAsync();
        public async Task<Cliente?> GetByIdAsync(int Id_Cliente)
            => await _context.Clientes.FindAsync(Id_Cliente);
        public async Task<Cliente> AddAsync(Cliente entity)
        {
            _context.Clientes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> UpdateAsync(Cliente entity)
        {
            _context.Clientes.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Clientes.FindAsync(id);
            if (existing == null) return false;
            _context.Clientes.Remove(existing);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
