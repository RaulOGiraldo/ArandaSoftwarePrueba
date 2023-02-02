using Bisiness.DTOs;
using Bisiness.interfaces;
using Bisiness.QueryFilters;
using Data.Entities;
using Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bisiness.Services
{
    public class ProductoServices : IProductoServices
    {
        private readonly IProductoRepository _productoRepository;
        public ProductoServices(IProductoRepository productoRepository)
        {
            //_productoRepository = new ProductoRepository();
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<ProductoDTO>> GelAll(ProductoQueryFilter filters)
        {
            bool ordenar = false;

            var productos = await _productoRepository.GetAll();

            if (!string.IsNullOrEmpty(filters.Nombre))
            {
                productos = productos.Where(x => x.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
                if (filters.Ordenamiento.ToUpper() == "DESC")
                {
                    productos = productos.OrderByDescending(x => x.Nombre);
                } else
                {
                    productos = productos.OrderBy(x => x.Nombre);
                }
                ordenar = true;
            }
            if (!string.IsNullOrEmpty(filters.Descripcion))
            {
                productos = productos.Where(x => x.Descripcion.ToLower().Contains(filters.Descripcion.ToLower()));
            }
            if (!string.IsNullOrEmpty(filters.Categoria))
            {
                productos = productos.Where(x => x.Categoria.ToLower().Contains(filters.Categoria.ToLower()));
                if (filters.Ordenamiento.ToUpper() == "DESC")
                {
                    productos = productos.OrderByDescending(x => x.Categoria);
                }
                else
                {
                    productos = productos.OrderBy(x => x.Categoria);
                }
                ordenar = true;
            }

            if (!ordenar)
            {
                if (filters.Ordenamiento.ToUpper() == "DESC")
                {
                    productos = productos.OrderByDescending(x => x.Id);
                } else
                {
                    productos = productos.OrderBy(x => x.Id);
                }
            }

            var listaDto = productos.Select(x =>
                new ProductoDTO
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Descripcion = x.Descripcion,
                    Categoria = x.Categoria,
                    Imagen = x.Imagen
                });

            return listaDto;
        }

        public async Task<Producto> Get(int Id)
        {
            var producto = await _productoRepository.Get(Id);
            return (producto);
        }

        public async Task<bool> Insert(Producto producto)
        {
            return await _productoRepository.Insert(producto);
        }

        public async Task<bool> Update(int Id, Producto producto)
        {
            return await _productoRepository.Update(Id, producto);
        }

        public async Task<bool> Delete(int Id)
        {
            return await _productoRepository.Delete(Id);
        }

    }
}
