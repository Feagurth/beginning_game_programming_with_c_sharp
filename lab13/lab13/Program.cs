using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleCards;

namespace lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating deck of cards
            Deck deckOfCards = new Deck();

            // Creating array of cards
            Card[] arrayCards = new Card[5];

            // Shufffling deck
            deckOfCards.Shuffle();

            // Getting a top card from the deck and setting it to the first
            // element of the array of cards
            arrayCards.SetValue(deckOfCards.TakeTopCard(), 0);

            // Flipping over the card and printing it
            arrayCards[0].FlipOver();
            arrayCards[0].Print();

            // Line separator
            Console.WriteLine();

            // Getting a top card from the deck and setting it to the second
            // element of the array of cards            
            arrayCards.SetValue(deckOfCards.TakeTopCard(), 1);

            // Flipping over the last card in the array
            arrayCards[1].FlipOver();

            // Printing both cards
            arrayCards[0].Print();
            arrayCards[1].Print();

        }
    }
}
