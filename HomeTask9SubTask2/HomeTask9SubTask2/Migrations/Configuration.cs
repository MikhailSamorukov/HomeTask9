namespace HomeTask9SubTask2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeTask9SubTask2.NorthwindContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HomeTask9SubTask2.NorthwindContext context)
        {
            context.Categories.AddOrUpdate(
              new Categories { CategoryID = 1, CategoryName = "test2" },
              new Categories { CategoryID = 2, CategoryName = "test3" },
              new Categories { CategoryID = 3, CategoryName = "test4" }
            );
            context.Region.AddOrUpdate(
              new Region { RegionID = 1, RegionDescription = "Kazakhstan" },
              new Region { RegionID = 2, RegionDescription = "Russia" }
            );
            context.Territories.AddOrUpdate(
              new Territories { RegionID = 1, TerritoryID = "1", TerritoryDescription = "Nice place" },
              new Territories { RegionID = 2, TerritoryID = "2", TerritoryDescription = "Beautiful place" }
            );
        }
    }
}
