using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingAssignment5
{
    class Program
    {
        /// <summary>
        /// War with dices
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            Random rand = new Random();

            int player1Roll;
            int player2Roll;
            int player1Wins = 0;
            int player2Wins = 0;
            bool quit = false;

            // Welcome message
            Console.WriteLine("Welcome to war!");

            while (!quit)
            {
                // Resetting the win games variables
                player1Wins = 0;
                player2Wins = 0;

                // To put some distance in the log between a game and another
                Console.WriteLine();

                // Start of the loop for simulating the 21 battles
                for (int i = 0; i < 21; i++)
                {
                    // Rolling dices for player1 and player2
                    player1Roll = rand.Next(1, 14);
                    player2Roll = rand.Next(1, 14);

                    // Checking if the roll was the same
                    if (player1Roll == player2Roll)
                    {
                        // If so, keep rolling dices until the rolls are diferent
                        do
                        {
                            // Declaring war and printing values to the screen
                            Console.WriteLine("  WAR!:\tP1: " + player1Roll + "\tP2: " + player2Roll);

                            // Rolling dice again
                            player1Roll = rand.Next(1, 14);
                            player2Roll = rand.Next(1, 14);

                        }
                        while (player1Roll == player2Roll);
                    }

                    // Checking who won
                    if (player1Roll > player2Roll)
                    {
                        // Player1 wins! Printing battle log to screen and increment wins counter for player1 by one
                        player1Wins++;
                        Console.WriteLine("BATTLE:\tP1: " + player1Roll + "\tP2: " + player2Roll + "\t P1 Wins!");
                    }
                    else
                    {
                        // Player2 wins! Printing battle log to screen and increment wins counter for player2 by one
                        player2Wins++;
                        Console.WriteLine("BATTLE:\tP1: " + player1Roll + "\tP2: " + player2Roll + "\t P2 Wins!");
                    }
                }

                // Adding some space to the log
                Console.WriteLine();

                // After the 21 battles, we check who won most battle to declare a winner
                if (player1Wins > player2Wins)
                {
                    Console.WriteLine("P1 is the overall Winner with " + player1Wins + " battles!");
                }
                else
                {
                    Console.WriteLine("P2 is the overall Winner with " + player2Wins + " battles!");
                }

                // Asking if want to play another game
                Console.Write("Do you want to play again (y/n)?");

                // Getting info of the key pressed and checking if the player want to quit
                if (Console.ReadKey().Key.ToString() == "N")
                {
                    // If so, we set the quit variable to true to allow the player end the game
                    quit = true;
                }

                // To put some distance in the log between a game and another
                Console.WriteLine();

            }
        }
    }
}
