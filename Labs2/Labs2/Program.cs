using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs2
{
    /// <summary>
    /// Lab 2 – Variables and Constants
    /// </summary>
    class Program
    {
        /// <summary>
        /// Lab 2 – Variables and Constants
        /// </summary>
        /// <param name="args">command-line-args</param>
        static void Main(string[] args)
        {

            // Problem 1 – Declaring and Using Variables
            int age = 36;

            Console.WriteLine("My age is: " + age);

            //Problem 2 – Declaring and Using Constants and Variables 

            const int MAX_SCORE = 100;
            int score = 85;
            float percent = (float)score / MAX_SCORE;

            Console.WriteLine("Percent score: " + percent);
            Console.WriteLine();
        }
    }
}
