using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a new deck and print the contents of the deck
            Deck deck = new Deck();

            // shuffle the deck and print the contents of the deck

            // Shuffling
            deck.Shuffle();

            //Printing
            deck.Print();
            Console.WriteLine();

            // take the top card from the deck and print the card rank and suit
            // Taking top Card
            Card card = deck.TakeTopCard();

            // Printing card
            Console.WriteLine("Rank: " + card.Rank + " Suit: " + card.Suit);
            Console.WriteLine();

            // take the top card from the deck and print the card rank and suit
            // Taking top Card
            card = deck.TakeTopCard();

            // Printing card
            Console.WriteLine("Rank: " + card.Rank + " Suit: " + card.Suit);

        }
    }
}
