using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Writing orders to user
            Console.Write("Input string in correct format: ");

            // Reading user's input and storing it in a variable
            string userInput = Console.ReadLine();

            // Initializing variables for storing the positions for the chunks of text
            int commaPosition = 0;
            int startSubString = 0;

            // Getting the position of the first comma
            commaPosition = userInput.IndexOf(',', commaPosition);

            // Getting the chunk of text between the start of the string and the first comma
            int pyramidSlotNumber = int.Parse(userInput.Substring(startSubString, commaPosition - startSubString).Trim());

            // Moving the start of the substring pointer una character beyond the last comma
            startSubString = commaPosition + 1;

            // Getting the position of the second comma
            commaPosition = userInput.IndexOf(',', commaPosition + 1);

            // Getting the chunk of text between the start of the string and the first comma
            string blockLetter = userInput.Substring(startSubString, commaPosition - startSubString).Trim();

            // Moving the start of the substring pointer una character beyond the last comma
            startSubString = commaPosition + 1;

            // Since there is no commas left to search for, we get the substring from the startSubString pointer to the lenght of the string
            Boolean blockLit = Boolean.Parse(userInput.Substring(startSubString, userInput.Length - startSubString).Trim());

            // Writing results
            Console.WriteLine("Pyramid Slot Number: " + pyramidSlotNumber.ToString());
            Console.WriteLine("Block Letter: " + blockLetter);
            Console.WriteLine("Block Lit: " + blockLit.ToString());


        }
    }
}
