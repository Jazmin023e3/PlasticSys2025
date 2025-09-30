using PlasticSYS.Models;

namespace PlasticSysAPi.Interfaces
{
    public interface IVentaRepository
    {
        Task<List<Venta>> GetAllAsync();
        Task<Venta?> GetByIdAsync(int Id_venta);
        Task<Venta> AddAsync(Venta entity);
        Task<bool> UpdateAsync(Venta entity);
        Task<bool> DeleteAsync(int Id_venta);
    }
}
