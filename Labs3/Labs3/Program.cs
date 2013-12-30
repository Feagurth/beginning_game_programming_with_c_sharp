using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs3
{
    /// <summary>
    /// Lab 3 – Calculations
    /// </summary>
    class Program
    {
        /// <summary>
        /// Lab 3 – Calculations
        /// </summary>
        /// <param name="args">command-line-args</param>
        static void Main(string[] args)
        {
            // Problem 1 – Basic Calculations

            // Variable declarations
            float originalFahrenheit = 0;
            float convertedCelsius = 0;
            float convertedFarenheit = 0;
            
            // Asking original Farenheit temp
            Console.Write("Enter temperature (Fahrenheit): ");
            originalFahrenheit = float.Parse(Console.ReadLine());
            Console.WriteLine();

            // Converting temps
            convertedCelsius = (((float)(originalFahrenheit - 32) / 9) * 5);
            convertedFarenheit = (((float)(convertedCelsius * 9) / 5) + 32);

            // Showing results
            Console.WriteLine(originalFahrenheit + " degrees Fahrenheit is " + convertedCelsius + " degrees Celsius.");
            Console.WriteLine(convertedCelsius + " degrees Celsius is " + convertedFarenheit + " degrees Fahrenheit.");
        }
    }
}
