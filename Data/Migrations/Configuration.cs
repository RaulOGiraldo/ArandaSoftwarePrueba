namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.Models.ArandaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Data.Models.ArandaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Productos.AddOrUpdate(x => x.Id, new Entities.Producto()
            {
                Id = 1,
                Nombre = "Portatil Lenovo",
                Descripcion = "Portail para desarrollo con procesador Intel core I7",
                Categoria = "Hardware",
                Imagen = "https://www.google.com/aclk?sa=l&ai=DChcSEwisnMmW4_L8AhUBiVoFHUqLAbYYABAJGgJ2dQ&sig=AOD64_1IIlzAS-jv1hLIFiL8ZI7Td-5DpA&adurl&ctype=5&ved=2ahUKEwjWjsCW4_L8AhXTkYQIHcKRBWkQvhd6BQgBEIUB"
            });
        }
    }
}
