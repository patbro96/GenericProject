namespace WebApplication7.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication7.Persistence.CarDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication7.Persistence.CarDbContext context)
        {
            context.Cars.AddOrUpdate(p => p.CarId,
                new Models.Car { Model = "Porsche", Color = "Czarny" },
                new Models.Car { Model = "Ferrari", Color = "Czerwony" });
        }
    }
}
