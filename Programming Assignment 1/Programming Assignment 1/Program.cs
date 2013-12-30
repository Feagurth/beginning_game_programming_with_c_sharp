using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Programming_Assignment_1
{
    /// <summary>
    /// Programming Assignment 1 - Game Statistics
    /// Application designed to show some statistics of a game
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main function
        /// Asks the user for gold and hours played and calculate the statistics of the game
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // Declaring constant
            const int MINUTES_PER_HOUR = 60;

            // Welcome and porpouse of the application
            Console.WriteLine();
            Console.WriteLine("Welcome!");
            Console.WriteLine("This application will calculate your average gold-collecting performance");
            Console.WriteLine();

            // Asking for gold
            Console.Write("How much god did you get? ");
            
            // Storing the user input in a variable
            int gold = int.Parse(Console.ReadLine());

            // Asking for time played
            Console.Write("How many hours have you played? ");

            // Storing the hours played by the user in a variable
            float hours = float.Parse(Console.ReadLine());

            // Calculating the minutes played by the user
            int minutes = (int)(hours * MINUTES_PER_HOUR);

            // Calculating the gold per minute ratio
            float goldPerMinute = (float)gold / minutes;

            // Showing results
            Console.WriteLine();
            Console.WriteLine("Total Gold: " + gold);
            Console.WriteLine("Hours Played: " + hours);
            Console.WriteLine("Gold per Minute: : " + goldPerMinute);
        }
    }
}
