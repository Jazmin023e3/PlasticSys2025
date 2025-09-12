using PlasticSYS.Models;

namespace PlasticSysAPI.Repositorios
{
    public interface IMarcaRepository
    {
        Task<IEnumerable<Marca>> GetMarcasAsync();
        // Agrega otros métodos como GetMarcaById, AddMarca, UpdateMarca, DeleteMarca
    }
}