using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ShopMVC___Kald.DatabaseContext
{
    public class GroceryStoreDatabaseInitializer : DropCreateDatabaseIfModelChanges<GroceryStoreDbContext>
    {
        protected override void Seed(GroceryStoreDbContext context)
        {
            context.Foods.AddOrUpdate(x => x.Name,
                new Models.Food
                {
                    Name = "apple",
                    Price = 1
                },
                   new Models.Food
                   {
                       Name = "bread",
                       Price = 0.80
                   },
                    new Models.Food
                    {
                        Name = "milk",
                        Price = 0.90
                    },
                     new Models.Food
                     {
                         Name = "chocolate",
                         Price = 1
                     },
                      new Models.Food
                      {
                          Name = "potatoes",
                          Price = 0.60
                      }
                );
        }
    }
}