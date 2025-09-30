using PlasticSYS.Models.DTOs;
using PlasticSysAPi.DTOS;

namespace PlasticSysAPi.Interfaces
{
    public interface IClienteService
    {
        Task<List<ClienteRespuestaDTO>> GetAllAsync();
        Task<ClienteRespuestaDTO?> GetByIdAsync(int Id_cliente);
        Task<ClienteRespuestaDTO> CreateAsync(ClienteCreateDto dto);
        Task<bool> UpdateAsync(int Id_cliente, ClienteActualizarDTO dto);
        Task<bool> DeleteAsync(int Id_cliente);
    }
}
