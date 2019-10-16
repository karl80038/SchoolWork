using ShopDatabaseKald.Models;

using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopDatabaseKald
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
            ShoppingCart newCart = new ShoppingCart();
            ShoppingCart secondCart = new ShoppingCart();

            ConsoleKey cKey;

            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1) Add a new product to the cart");
                Console.WriteLine("2) Go to checkout");
                cKey = Console.ReadKey().Key;

                if (cKey == ConsoleKey.D1)
                {
                    while (true)
                    {
                        Console.WriteLine("We're currently selling the following items: ");
                        foreach (Food f in groceries)
                        {
                            Console.WriteLine($"{f.Name}, {f.Price}");
                        }
                        Console.WriteLine("Please enter the name of the item you'd like to buy: ");
                        string Answer = Console.ReadLine();
                        if (Answer != "")
                        {
                            char[] a = Answer.ToCharArray();

                            a[0] = char.ToUpper(a[0]);

                            int ct = a.Count();

                            for (int i = 1; i < ct; i++)
                            {
                                a[i] = char.ToLower(a[i]);
                            }


                            Answer = new string(a);
                        }
                        foreach (var item in groceries)
                        {
                            if (item.Name == Answer)
                            {
                                secondCart.AddToCart(item);
                                Console.WriteLine($"{Answer} was successfully added to the cart");
                            }
                        }

                        while (true)
                        {
                            Console.WriteLine("Is that it? (Y/N) ");
                            cKey = Console.ReadKey().Key;
                            if (cKey == ConsoleKey.Y | cKey == ConsoleKey.N)
                            {
                                break;
                            }
                        }
                        if (cKey == ConsoleKey.Y)
                        {
                            break;
                        }
                        Console.Clear();
                    }
                    if (cKey == ConsoleKey.Y)

                    {
                        break;
                    }


                }
                
                if (cKey == ConsoleKey.D2)
                {
                    break;
                }
                if (cKey == ConsoleKey.Y)

                {
                    break;
                }
            }

                foreach (var food in groceries)
                {
                    newCart.Items.Add(food);
                }

                using (var db = new ShopDbContext())
                {
                    db.ShoppingCarts.Add(newCart);

                    if (secondCart.Items.Count >= 1)
                    {
                        db.ShoppingCarts.Add(secondCart);
                    }

                    db.SaveChanges();
                Console.Clear();
                    var carts = db.ShoppingCarts.Include("Items").OrderByDescending(x => x.DateCreated).ToList();
                IQueryable<ShoppingCart> cartWithZeroSum = db.ShoppingCarts.Where(x => x.Sum == 0);
                foreach (var cart in cartWithZeroSum)
                {
                    db.ShoppingCarts.Remove(cart);

                }
                db.SaveChanges();
                
                    foreach (var cart in carts)
                    {
                    Console.WriteLine($"Shopping cart created: {cart.DateCreated}");
                    foreach (var food in cart.Items)
                        {
                        

                            Console.WriteLine($"Name: {food.Name}, Price: {food.Price}");

                        }
                    Console.WriteLine($"Total: {cart.Sum}");
                    }
                }

                Console.WriteLine("The program's currently running...");
                Console.WriteLine("Press any key to terminate the program");
                Console.ReadKey();

            }
        }
    }


