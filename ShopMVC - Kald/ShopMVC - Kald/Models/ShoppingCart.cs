using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMVC___Kald.Models
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public Double Sum { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<Food> Items { get; set; }

        public ShoppingCart()
        {
            Id = Guid.NewGuid();
            Sum = 0;
            DateCreated = DateTime.Now;
            Items = new List<Food>();
        }
    }
}