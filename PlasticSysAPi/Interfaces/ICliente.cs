using System.Collections.Generic;
using System.Threading.Tasks;
using PlasticSYS.Models;

namespace PlasticSysAPI.Interfaces
{
    public interface ICliente
    {
        Task<IEnumerable<Cliente>> GetAllClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task AddClienteAsync(Cliente cliente);
        Task UpdateClienteAsync(Cliente cliente);
        Task DeleteClienteAsync(int id);
    }
}