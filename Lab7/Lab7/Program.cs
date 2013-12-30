using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {

            // Asking for month of birth
            Console.Write("In what month were you born?: ");

            // Storing it in a string variable
            string month = Console.ReadLine();

            // Asking for day of birth
            Console.Write("On what day were you born?: ");

            // Storing it in a integer variable
            int day = int.Parse(Console.ReadLine());

            // Showing results
            Console.WriteLine("Your birthday is " + month + " " + day.ToString());
            Console.WriteLine("You'll get an email with a discount offer on " + month + " " + (day -1).ToString());




        }
    }
}
