using PlasticSYS.Models;
using PlasticSYS.Models.DTOs;
using PlasticSysAPi.DTOS;
using PlasticSysAPi.Interfaces;
using PlasticSysAPI.Interfaces;

namespace PlasticSysAPi.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repo;
        public ClienteService(IClienteRepository repo) => _repo = repo;
        public async Task<List<ClienteRespuestaDTO>> GetAllAsync() =>
            (await _repo.GetAllAsync()).Select(x => new ClienteRespuestaDTO
            {
                ClienteId = x.ClienteId,
                Nombre = x.Nombre,
                Correo = x.Correo,
                Telefono = x.Telefono
            }).ToList();
        public async Task<ClienteRespuestaDTO?> GetByIdAsync(int id)
        {
            var x = await _repo.GetByIdAsync(id);
            return x == null ? null : new ClienteRespuestaDTO
            {
                ClienteId = x.ClienteId,
                Nombre = x.Nombre,
                Correo = x.Correo,
                Telefono = x.Telefono
            };
        }
        public async Task<ClienteRespuestaDTO> CreateAsync(ClienteCreateDto dto)
        {
            var entity = new Cliente { Nombre = dto.Nombre.Trim(), Correo = dto.Correo.Trim() , Telefono = dto.Telefono.Trim( )};
            var saved = await _repo.AddAsync(entity);
            return new ClienteRespuestaDTO { ClienteId = saved.ClienteId, Nombre = saved.Nombre, Correo = saved.Correo , Telefono =saved.Telefono };
        }

        public async Task<bool> UpdateAsync(int Id_Cliente, ClienteActualizarDTO dto)
        {
            var current = await _repo.GetByIdAsync(Id_Cliente);
            if (current == null) return false;
            current.Nombre = dto.Nombre.Trim();
            current.Correo = dto.Correo.Trim();
            current.Telefono = dto.Telefono.Trim();
            return await _repo.UpdateAsync(current);
        }

        public Task<bool> DeleteAsync(int Id_Cliente) => _repo.DeleteAsync(Id_Cliente);
    }
}

