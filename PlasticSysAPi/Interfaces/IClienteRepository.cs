using System.Collections.Generic;
using System.Threading.Tasks;
using PlasticSYS.Models;

namespace PlasticSysAPI.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(int Id_Cliente);
        Task<Cliente> AddAsync(Cliente entity);
        Task<bool> UpdateAsync(Cliente entity);
        Task<bool> DeleteAsync(int Id_Cliente);
    }
}