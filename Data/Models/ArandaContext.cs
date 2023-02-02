using Data.Entities;
using System.Data.Entity;

namespace Data.Models
{
    public class ArandaContext : DbContext
    {
        public ArandaContext() :base("DefaultConnection")
        {

        }
        public DbSet<Producto> Productos { get; set; }
    }
}
