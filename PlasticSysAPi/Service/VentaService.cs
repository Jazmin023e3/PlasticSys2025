using PlasticSYS.Models;
using PlasticSysAPi.DTOS;
using PlasticSysAPi.Interfaces;

namespace PlasticSysAPi.Service
{
    public class VentaService :IVentaService
    {
        private readonly IVentaRepository _repo;

        public VentaService(IVentaRepository repo) => _repo = repo;

        // 1.Servicio para obtener todos los documentos
        public async Task<List<VentaRespuestaDTO>> GetAllAsync() =>
            (await _repo.GetAllAsync()).Select(x => new VentaRespuestaDTO
            {
                VentaId = x.VentaId,
                Fecha = x.Fecha,
                Total = x.Total,
                ClienteId = x.ClienteId
               
            }).ToList();

        // 2.Servicio para obtener documento por ID
        public async Task<VentaRespuestaDTO?> GetByIdAsync(int id)
        {
            var x = await _repo.GetByIdAsync(id);
            return x == null ? null : new VentaRespuestaDTO
            {
                VentaId = x.VentaId,
                Fecha = x.Fecha,
                Total = x.Total,
                ClienteId = x.ClienteId
            };
        }


        // 3.Servicio para crear un documento
        public async Task<VentaRespuestaDTO> CreateAsync(VentaCrearDTO dto)
        {
            var entity = new Venta
            {
                Fecha = dto.Fecha,
                Total = dto.Total,
                ClienteId = dto.ClienteId, // Si el dato que esta en la entidad es int , date o un dato que no sea tipo string 
            };                                                                                                                                 // Entonces no se usa .Trim() y solo se hace por ejemplo 
                                                                                                                                               // TipoDocumentoId = dto.TipoDocumentoId , al ser int solo se pone = dto.nombredelcampo
            var saved = await _repo.AddAsync(entity);
            return new VentaRespuestaDTO
            {
                VentaId = saved.VentaId,
                Fecha = saved.Fecha,
                Total = saved.Total,
                ClienteId = saved.ClienteId//var es para que Guarden todos los datos incluyendo el id
            };
        }

        // 4.Servicio para actualizar un documento
        public async Task<bool> UpdateAsync(int Id_venta, VentaActualizarDTO dto)
        {
            var current = await _repo.GetByIdAsync(Id_venta);
            if (current == null) return false;
            current.Fecha = dto.Fecha;
            current.Total = dto.Total;
            current.ClienteId = dto.ClienteId;
            return await _repo.UpdateAsync(current);
        }

        // 5.Servicio para eliminar un documento por ID
        public Task<bool> DeleteAsync(int Id_venta) => _repo.DeleteAsync(Id_venta);
    }
}
