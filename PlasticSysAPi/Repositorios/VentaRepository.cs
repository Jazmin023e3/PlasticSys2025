using Microsoft.EntityFrameworkCore;
using PlasticSYS.Models;
using PlasticSysAPi.Context;
using PlasticSysAPi.Interfaces;

namespace PlasticSysAPi.Repositorios
{
    public class VentaRepository :IVentaRepository
    {
        private readonly AppDbContext _context;
        public VentaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Venta>> GetAllAsync()
          => await _context.Ventas.AsNoTracking().ToListAsync();

        public async Task<Venta?> GetByIdAsync(int Id_venta)
            => await _context.Ventas.FindAsync(Id_venta);

        public async Task<Venta> AddAsync(Venta entity)
        {
            _context.Ventas.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(Venta entity)
        {
            _context.Ventas.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Ventas.FindAsync(id);
            if (existing == null) return false;
            _context.Ventas.Remove(existing);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
