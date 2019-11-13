using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ShopDatabaseKald.Models
{
   public class Customer
    {
      public  string FirstName { get; set; }
      public  string LastName { get; set; }
        [Key]
      public  int PID { get; set; } 
        int VisitCount { get; set; }

        DateTime CustomerSince { get; set; }
        public  virtual ICollection<ShoppingCart> Purchases { get; set; }
        public virtual ICollection<Food> Items { get; set; }

        public Customer(string firstName, string lastName, int pID)
        {

            FirstName = firstName;
            LastName = lastName;
            PID = pID;
            Purchases = new List<ShoppingCart>();
            CustomerSince = DateTime.Now.Date;

        }
        
        public void NewCart (ShoppingCart newCart)
        {
            Purchases.Add(newCart);
            VisitCount += 1;
        }

        public override string ToString()
        {
            return $"First Name: {FirstName} \nLast Name: {LastName}\nPerson's ID: {PID} \nCustomer since: {CustomerSince.ToLongDateString()}\nVisited us: {VisitCount} times\n\n";
        }

    }
        
    }

