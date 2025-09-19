using System.Collections.Generic;
using System.Threading.Tasks;
using PlasticSYS.Models;

namespace PlasticSysAPI.Interfaces
{
    public interface IProducto
    {
        Task<IEnumerable<Producto>> GetAllProductosAsync();
        Task<Producto> GetProductoByIdAsync(int id);
        Task AddProductoAsync(Producto producto);
        Task UpdateProductoAsync(Producto producto);
        Task DeleteProductoAsync(int id);
    }
}