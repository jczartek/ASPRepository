namespace Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Model.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Model.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            if (!context.Categories.Any(x => x.Name == "Kategoria 1"))
            {
                context.Categories.AddOrUpdate(x => x.Id, new Entities.Category { Name = "Kategoria 1" });
                context.SaveChanges();
            }

            if (!context.Categories.Any(x=> x.Name == "Produkt 1"))
            {
                var category = context.Categories.First(x => x.Name == "Kategoria 1");

                var product = new Entities.Product
                {
                    Name = "Product 1",
                    Price = 15m,
                    CategoryId = category.Id
                };
                context.Products.AddOrUpdate(x => x.Id, product);
                context.SaveChanges();
            }
        }
    }
}
