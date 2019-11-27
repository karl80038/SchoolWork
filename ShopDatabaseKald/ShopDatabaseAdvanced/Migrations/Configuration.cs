namespace ShopDatabaseAdvanced.Migrations
{
    using ShopDatabaseKald.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopDatabaseAdvanced.AdvancedShopdatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ShopDatabaseAdvanced.ShopAdvancedDbContext.AdvancedShopdatabaseContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ShopDatabaseAdvanced.AdvancedShopdatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //context.Customers.AddOrUpdate
            //    (
            //    customer => customer.FirstName
            //    );
            context.Foods.AddOrUpdate(
                food => food.Name,
                new Food
                {
                    Name = "apple",
                    Price = 1.7
                },

                new Food
                {
                    Name = "bread",
                    Price = 1.2
                },

                new Food
                {
                    Name = "cheese",
                    Price = 2
                },

                new Food
                {
                    Name = "potato",
                    Price = 0.60
                }

                );

        }
    }
}
