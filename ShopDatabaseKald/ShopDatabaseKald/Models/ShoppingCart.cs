﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopDatabaseKald.Models
{
   public class ShoppingCart
    {
        public Guid Id { get; set; }

        public double Sum { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<Food> Items { get; set; }

        public ShoppingCart()
        {
            Id = Guid.NewGuid();
            Items = new List<Food>();
            Sum = 0;
            DateCreated = DateTime.Now;
        }

        internal void AddToCart(Food itemToAdd)
        {
            Items.Add(itemToAdd);
            Sum += itemToAdd.Price;
        }
    }
}
