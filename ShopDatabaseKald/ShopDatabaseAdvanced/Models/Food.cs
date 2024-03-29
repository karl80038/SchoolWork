﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopDatabaseKald.Models
{
    public class Food
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCart {get;set;}

        public Food()
        {
            Id = Guid.NewGuid();
        }

        public Food(string name, double price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"Item: {Name}, Price: {Price}";
        }

    }
}
