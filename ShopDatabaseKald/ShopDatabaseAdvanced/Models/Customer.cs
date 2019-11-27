using ShopDatabaseKald.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ShopDatabaseKald.Models
{
   public class Customer
    {
        public string PersonaId { get; set; }
        public  string FirstName { get; set; }
      public  string LastName { get; set; }
        [Key]
      public  Guid PID { get; set; } 

        int VisitCount { get; set; }

        DateTime CustomerSince { get; set; }
        public  virtual ICollection<ShoppingCart> Purchases { get; set; }

        public Customer()
        {
            PID = Guid.NewGuid();
            Purchases = new List<ShoppingCart>();
        }

        public Customer(string firstName, string lastName, string pID)
        {
            PID = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            PersonaId = pID;
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

