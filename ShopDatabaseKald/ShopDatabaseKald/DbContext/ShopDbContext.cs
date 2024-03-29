﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using ShopDatabaseKald.Models;

namespace ShopDatabaseKald
{
   public class ShopDbContext : DbContext
    {
        public ShopDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopDbContext, Migrations.Configuration>());
        }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<Food> Foods { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingCart>()
                .HasMany(c => c.Items)
                .WithRequired(c => c.ShoppingCart)
                .WillCascadeOnDelete();

        }

    }



}
