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
                //    var carts = db.ShoppingCarts.Include("Items").OrderByDescending(x => x.DateCreated).ToList();
                //IQueryable<ShoppingCart> cartWithZeroSum = db.ShoppingCarts.Where(x => x.Sum == 0);
                //foreach (var cart in cartWithZeroSum)
                //{
                //    db.ShoppingCarts.Remove(cart);

                //}
                //db.SaveChanges();

                //    foreach (var cart in carts)
                //    {
                //    Console.WriteLine($"Shopping cart created: {cart.DateCreated}");
                //    foreach (var food in cart.Items)
                //        {


                //            Console.WriteLine($"Name: {food.Name}, Price: {food.Price}");

                //        }
                //    Console.WriteLine($"Total: {cart.Sum}");
                //    }
                //}
                var carts = db.ShoppingCarts;

                var cartsWithItems = db.ShoppingCarts.Include("Items");
                var foods = db.Foods;

                //1. Last created cart

                var latest = cartsWithItems.OrderByDescending(x => x.DateCreated).ToList().First();
                var latest2 = cartsWithItems.OrderBy(cart => cart.DateCreated).ToList().Last();

                Console.WriteLine($"The last cart cart was created on {latest.DateCreated}");
                Console.WriteLine($"The last cart cart was created on {latest2.DateCreated}");

                //2. Carts with Sum > 5

                Console.WriteLine("Show carts where sum is larger than five");

                var carts5 = carts.Where(x => x.Sum > 5).ToList();
                foreach (var cart in carts5)
                {
                    Console.WriteLine($"Shopping cart created on {cart.DateCreated} Sum: {cart.Sum}");
                }

                //3. Carts with more than one item (make sure to display the amount of items as well)

                Console.WriteLine("Excercise 3: Only show carts that have more than one item");

                var cartsMoreThan1 = cartsWithItems.Where(x => x.Items.Count() > 1);

                foreach (var cart in cartsMoreThan1) {  Console.WriteLine($"Shopping cart created on {cart.DateCreated}, there are {cart.Items.Count} items in this cart, Total: {cart.Sum}");  }

                Console.WriteLine("Excercise 3 with query syntax");

                var cartsMoreThan1_query = from cart in cartsWithItems where cart.Items.Count() > 1 select cart;
                foreach (var cart in cartsMoreThan1_query) { Console.WriteLine($"Shopping cart created on {cart.DateCreated}, there are {cart.Items.Count} items in this cart, Total: {cart.Sum}"); }

                //4. Only carts that contain bananas will be shown
                Console.WriteLine("Excercise 4: Show carts that contain at least one banana");

                var cartsWithBananas = cartsWithItems.Where(x => x.Items.Any(y => y.Name == "Banana"));
                foreach (var cart in cartsWithBananas)
                {
                    Console.WriteLine($"Shopping cart created on {cart.DateCreated}, there are {cart.Items.Count} items in this cart, Total: {cart.Sum}" );
                    foreach (var food in cart.Items)
                    {
                        Console.WriteLine($"Item's Name: {food.Name}, Item's Price: {food.Price}");
                    }
                }

                //5. Show the total amount of carts
                Console.WriteLine("Excercise 5: Show the total amount of carts created");
                var count = carts.Count();
                Console.WriteLine($"There are a total of {count} carts");

                //6.Show the cart with the highest sum
                Console.WriteLine("Excercise 6: Only the cart with the highest sum will be shown");
                var cartWithMaxSum = carts.OrderByDescending(x => x.Sum).FirstOrDefault();
                Console.WriteLine($"Cart created on {cartWithMaxSum.DateCreated}, Sum = {cartWithMaxSum.Sum}");

                //7. Only the cheapest food item will be shown
                Console.WriteLine("Excercise 7: Show the cheapest food");
                var cheapestFood = foods.OrderByDescending(x => x.Price).ToList().Last();
                Console.WriteLine($"The cheapest food is {cheapestFood.Name}, Price {cheapestFood.Price}");

                Console.WriteLine("The program's currently running...");
                Console.WriteLine("Press any key to terminate the program");
                Console.ReadKey();

               

            }
        }
    }
}


