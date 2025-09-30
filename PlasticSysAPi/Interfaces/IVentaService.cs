

using PlasticSysAPi.DTOS;

namespace PlasticSysAPi.Interfaces
  
{
    public interface IVentaService
    {
        Task<List<VentaRespuestaDTO>> GetAllAsync();
        Task<VentaRespuestaDTO?> GetByIdAsync(int Id_venta);
        Task<VentaRespuestaDTO> CreateAsync(VentaCrearDTO dto);
        Task<bool> UpdateAsync(int Id_venta, VentaActualizarDTO dto);
        Task<bool> DeleteAsync(int Id_venta);
    }
}
