using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleCards;

namespace lab14b
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck myDeck = new Deck();
            List<Card> myList = new List<Card>();
            
            myDeck.Shuffle();

            for (int i = 0; i < 5; i++)
            {
                myList.Add(myDeck.TakeTopCard());
            }

            foreach (Card item in myList)
            {
                item.FlipOver();
                item.Print();
            }

        }
    }
}
