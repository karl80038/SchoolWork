using ShopDatabaseAdvanced.ShopAdvancedDbContext;
using ShopDatabaseKald.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopDatabaseAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Food> groceries = new List<Food>
            {
                new Food("Apple", 1.7),
                new Food("Bread", 1.2),
                new Food("Cheese", 2)
            };

            using (var db = new AdvancedShopdatabaseContext())
            {
                //db.Foods.AddRange(groceries);

                //ConsoleKey cKey;

                Console.WriteLine("Please enter your first name: ");
                string fName = Console.ReadLine();
                Console.WriteLine("Please enter your last name: ");
                string lName = Console.ReadLine();
                Console.WriteLine("Please enter your personal identification number (usually it's your social security number or personal code...");
                string idToConvert = Console.ReadLine();
                int pid;
               bool Success = int.TryParse(idToConvert, out pid);
                ShoppingCart newCart = new ShoppingCart();
                if (fName != "" & lName != "" & Success)
                {
                Customer searchResult = db.Customers.FirstOrDefault(x => x.FirstName == fName & x.LastName == lName);
                if (searchResult == null)
                {
                    db.Customers.Add(searchResult);
                }
                db.SaveChanges();
                searchResult.Purchases.Add(newCart);
                }
              

             
                while (true)
                {
                    ChooseFood(db, newCart);
                    Console.WriteLine("Anything else? Yes/No");
                    string answer = Console.ReadLine();
                    if (answer == "No" | answer == "no")
                    {
                        break;
                    }
                    else
                    {
                        answer = "";
                    }
                }


                //db.ShoppingCarts.Add(newCart);
                //ChooseFood(db, newCart);
                //    while (true)
                //    {
                //        ChooseFood(db, newCart);
                //        Console.WriteLine("Anything else? Yes/No");
                //       string answer = Console.ReadLine();
                //        if (answer == "No" | answer == "no")
                //        {
                //            break;
                //        }
                //        else
                //        {
                //            answer = "";
                //        }
                //    }
                //    db.SaveChanges();
                //    var ShoppingCarts = db.ShoppingCarts.Include("Items");
                //    foreach (var cart in ShoppingCarts)
                //    {
                //        Console.WriteLine($"Shopping cart created on: {cart.DateCreated}");
                //        foreach (var food in cart.Items)
                //        {
                //            Console.WriteLine($"Food Name: {food.Name}, Price {food.Price}");
                //        }
                //        Console.WriteLine($"Total: {cart.Sum}");
                //    }
                //}

                //while (true)
                //{
                //    Console.WriteLine("What would you like to do?");
                //    Console.WriteLine("1) Add a new product to the cart");
                //    Console.WriteLine("2) Go to checkout");
                //    cKey = Console.ReadKey().Key;

                //    if (cKey == ConsoleKey.D1)
                //    {
                //        while (true)
                //        {
                //            Console.WriteLine("We're currently selling the following items: ");
                //            foreach (Food f in groceries)
                //            {
                //                Console.WriteLine($"{f.Name}, {f.Price}");
                //            }
                //            Console.WriteLine("Please enter the name of the item you'd like to buy: ");
                //            string Answer = Console.ReadLine();
                //            if (Answer != "")
                //            {
                //                char[] a = Answer.ToCharArray();

                //                a[0] = char.ToUpper(a[0]);

                //                int ct = a.Count();

                //                for (int i = 1; i < ct; i++)
                //                {
                //                    a[i] = char.ToLower(a[i]);
                //                }


                //                Answer = new string(a);
                //            }
                //            foreach (var item in groceries)
                //            {
                //                if (item.Name == Answer)
                //                {
                //                    //secondCart.AddToCart(item);
                //                    Console.WriteLine($"{Answer} was successfully added to the cart");
                //                }
                //            }

                //            while (true)
                //            {
                //                Console.WriteLine("Is that it? (Y/N) ");
                //                cKey = Console.ReadKey().Key;
                //                if (cKey == ConsoleKey.Y | cKey == ConsoleKey.N)
                //                {
                //                    break;
                //                }
                //            }
                //            if (cKey == ConsoleKey.Y)
                //            {
                //                break;
                //            }
                //            Console.Clear();
                //        }
                //        if (cKey == ConsoleKey.Y)

                //        {
                //            break;
                //        }


                //    }

                //    if (cKey == ConsoleKey.D2)
                //    {
                //        break;
                //    }
                //    if (cKey == ConsoleKey.Y)

                //    {
                //        break;
                //    }
                //}

                //foreach (var food in groceries)
                //{
                //    newCart.Items.Add(food);p
                //}
                Console.ReadKey();
            }
        }
            private static void ChooseFood(AdvancedShopdatabaseContext db, ShoppingCart newCart)
            {
                Console.WriteLine("Enter the name of the product you'd like to add to the cart:");
                string foodName = Console.ReadLine();
                Food chosenFood = db.Foods.FirstOrDefault(x => x.Name == foodName);
                if (chosenFood != null)
                {
                    newCart.AddToCart(chosenFood);

                }
                else
                {
                    Console.WriteLine("The item you specified you specified is not available in the store. ");
                }
            }
        }
    } 
