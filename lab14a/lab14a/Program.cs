using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab14a
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inset lower bound: ");
            int lowerBound = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inser upper bound: ");
            int upperBound = Convert.ToInt32(Console.ReadLine());


            for (int i = lowerBound; i <= upperBound; i++)
            {
                Console.WriteLine(i);
                
            }
        }
    }
}
