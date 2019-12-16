using ShopMVC___Kald.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Core;
using System.Data.Entity.Utilities;
using System.Linq;
using System.Web;

namespace ShopMVC___Kald.DatabaseContext
{
    public class GroceryStoreDbContext : DbContext
    {
        public DbSet<Food> Foods {get; set;}
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected void onModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}