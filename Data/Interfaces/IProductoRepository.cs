using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAll();
        Task<Producto> Get(int Id);
        Task<bool> Insert(Producto producto);
        Task<bool> Update(int Id, Producto producto);
        Task<bool> Delete(int Id);
    }
}