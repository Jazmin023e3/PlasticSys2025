using System.Collections.Generic;
using System.Threading.Tasks;
using PlasticSYS.Models;


// Este es el namespace donde probablemente se encuentre tu modelo Marc

namespace PlasticSysAPI.Interfaces
{
    // La interfaz define los métodos que una clase de repositorio o servicio debe implementar.
    public interface IMarca
    {
        // Método para obtener todas las marcas
        Task<IEnumerable<Marca>> GetAllMarcasAsync();

        // Método para obtener una marca por su ID
        Task<Marca> GetMarcaByIdAsync(int id);

        // Método para agregar una nueva marca
        Task AddMarcaAsync(Marca marca);

        // Método para actualizar una marca existente
        Task UpdateMarcaAsync(Marca marca);

        // Método para eliminar una marca por su ID
        Task DeleteMarcaAsync(int id);
    }
}
