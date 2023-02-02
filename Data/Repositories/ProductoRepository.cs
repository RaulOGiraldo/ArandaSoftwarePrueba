using Data.Entities;
using Data.Interfaces;
using Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ArandaContext context;
        public ProductoRepository(ArandaContext _context)
        {
            //context = new ArandaContext();
            context = _context;
        }
        public async Task<IEnumerable<Producto>> GetAll()
        {
            var productos = await context.Productos.ToListAsync();
            return productos;
        }

        public async Task<Producto> Get(int Id)
        {
            var producto = await context.Productos.FirstOrDefaultAsync(x => x.Id == Id);
            return (producto);
        }

        public async Task<bool> Insert(Producto producto)
        {
            context.Productos.Add(producto);
            var regs = await context.SaveChangesAsync();
            return (regs > 0);
        }

        public async Task<bool> Update(int Id, Producto producto)
        {
            var currentAct = await Get((int)producto.Id);
            currentAct.Nombre = producto.Nombre;
            currentAct.Descripcion = producto.Descripcion;
            currentAct.Categoria = producto.Categoria;
            currentAct.Imagen = producto.Imagen;

            var regs = await context.SaveChangesAsync();
            return (regs > 0);
        }

        public async Task<bool> Delete(int Id)
        {
            var currentAct = await Get(Id);
            context.Productos.Remove(currentAct);
            var regs = await context.SaveChangesAsync();

            return (regs > 0);
        }

    }
}
