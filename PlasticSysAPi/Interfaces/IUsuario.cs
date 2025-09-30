using System.Collections.Generic;
using System.Threading.Tasks;
using PlasticSYS.Models;

namespace PlasticSysAPI.Interfaces
{
    public interface IUsuario
    {
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
        Task<Usuario> GetUsuarioByIdAsync(int id);
        Task AddUsuarioAsync(Usuario usuario);
        Task UpdateUsuarioAsync(Usuario usuario);
        Task DeleteUsuarioAsync(int id);
    }
}