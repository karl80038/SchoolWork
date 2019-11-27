using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMVC___Kald.DatabaseContext
{
    public class GroceryStoreDbContext : DbContext
    {
        public DbSet<Food> Foods {get; set;}
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void onModelCreating()
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}