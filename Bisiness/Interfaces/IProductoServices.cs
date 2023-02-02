using Bisiness.CustomEntities;
using Bisiness.DTOs;
using Data.Entities;
using System.Threading.Tasks;

namespace Bisiness.interfaces
{
    public interface IProductoServices
    {
        Task<PageList<ProductoDTO>> GelAll(QueryFilters.ProductoQueryFilter filters);
        Task<Producto> Get(int Id);
        Task<bool> Insert(Producto producto);
        Task<bool> Update(int Id, Producto producto);
        Task<bool> Delete(int Id);
    }
}