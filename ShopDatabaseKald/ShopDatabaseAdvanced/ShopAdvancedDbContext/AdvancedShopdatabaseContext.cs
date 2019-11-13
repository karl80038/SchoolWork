using ShopDatabaseKald.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ShopDatabaseAdvanced.ShopAdvancedDbContext
{
    class AdvancedShopdatabaseContext : DbContext
    {
        public AdvancedShopdatabaseContext() : base("ShoppingDatabase")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AdvancedShopdatabaseContext, Migrations.Configuration>());
        }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<Food> Foods { get; set; }

        public DbSet<Customer> Customers { get; set; }
    }
}
