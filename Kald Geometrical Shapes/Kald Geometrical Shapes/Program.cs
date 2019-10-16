using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kald_Geometrical_Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Clear();

            ConsoleKey Ckey = new ConsoleKey();


            while (true)

            {
                Console.WriteLine("Geometry Calculator\n*******************");
                Console.WriteLine("\nSelect the shape you wish to calculate (use numeric keys on your keyboard to make your selection): ");
                Console.WriteLine("1) Square");
                Console.WriteLine("2) Circle");
                Console.WriteLine("3) Triangle");
                Console.WriteLine("4) Rectangle");
                Console.WriteLine("5) Quit");

                Ckey = Console.ReadKey().Key;
                Console.Clear();

                if (Ckey == ConsoleKey.D1)
                {
                    double Val = 0;
                    while (true)
                    {
                        
                        Console.WriteLine("Enter the length of square: ");
                        string ReadVal = Console.ReadLine();
                       bool WasSuccessful = double.TryParse(ReadVal, out Val);

                        if (WasSuccessful)
                        {
                            break;
                        }
                    }
                    Square square = new Square(Val);
                    Console.WriteLine(square);
                    Console.ReadKey();
                    
                }

               else if (Ckey == ConsoleKey.D2)
                {

                }

               else if (Ckey == ConsoleKey.D3)
                {

                }

                else if (Ckey == ConsoleKey.D4)
                {

                }
                
                else if (Ckey == ConsoleKey.D5)
                {
                    while (true)
                    {
                        Console.WriteLine("Are you sure you want to quit? (Y/N)");
                        Ckey = Console.ReadKey().Key;

                        if (Ckey == ConsoleKey.Y)
                        {
                            System.Diagnostics.Process.GetCurrentProcess().Kill();
                        }

                        else if (Ckey == ConsoleKey.N)
                        {
                            break;
                        }
                        Console.Clear();
                    }
                }
                Console.Clear();
            }
        }
    }
}
