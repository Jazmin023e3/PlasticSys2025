using System.Collections.Generic;
using System.Threading.Tasks;
using PlasticSYS.Models;

namespace PlasticSysAPI.Interfaces
{
    public interface IVenta
    {
        Task<IEnumerable<Venta>> GetAllVentasAsync();
        Task<Venta> GetVentaByIdAsync(int id);
        Task AddVentaAsync(Venta venta);
        Task UpdateVentaAsync(Venta venta);
        Task DeleteVentaAsync(int id);
    }
}