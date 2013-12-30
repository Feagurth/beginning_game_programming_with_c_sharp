using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {

            // Constant to choose between if selection o switch selection
            const Boolean SWITCH_SELECTION = true;

            // Drawing the menu
            Console.WriteLine("**************");
            Console.WriteLine("Menu: ");
            Console.WriteLine("");
            Console.WriteLine("1 - New game");
            Console.WriteLine("2 - Load game");
            Console.WriteLine("3 - Options");
            Console.WriteLine("4 - Quit");
            Console.WriteLine("**************");

            string choice = Console.ReadLine();

            if (SWITCH_SELECTION)
            {
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Starting new game...");
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Loading game...");
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Loading options...");
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Quitting game...");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Bad choice..");
                        break;
                }
            }
            else
            {
                if (choice == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Starting new game...");
                }
                else if (choice == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Loading game...");
                }
                else if (choice == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Loading options...");
                }
                else if (choice == "4")
                {
                    Console.Clear();
                    Console.WriteLine("Quitting game...");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Bad choice..");
                }
            }

        }
    }
}
