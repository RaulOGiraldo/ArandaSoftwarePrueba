using Bisiness.DTOs;
using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bisiness.interfaces
{
    public interface IProductoServices
    {
        Task<IEnumerable<ProductoDTO>> GelAll(QueryFilters.ProductoQueryFilter filters);
        Task<Producto> Get(int Id);
        Task<bool> Insert(Producto producto);
        Task<bool> Update(int Id, Producto producto);
        Task<bool> Delete(int Id);
    }
}