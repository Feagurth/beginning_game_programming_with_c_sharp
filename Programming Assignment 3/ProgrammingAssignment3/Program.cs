using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleCards;

namespace ProgrammingAssignment3
{
    class Program
    {
        static void Main(string[] args)
        {

            // Creating the deck and the two hands
            Deck deckOfCards = new Deck();
            BlackjackHand playerHand = new BlackjackHand("Player");
            BlackjackHand dealerHand = new BlackjackHand("Dealer");

            // Welcome message
            Console.WriteLine("Hello! This program will play a single hand of Blackjack");

            // Shuffling the deck
            deckOfCards.Shuffle();

            // Dealing cards to the player
            playerHand.AddCard(deckOfCards.TakeTopCard());
            playerHand.AddCard(deckOfCards.TakeTopCard());

            // Dealing cards to the dealer
            dealerHand.AddCard(deckOfCards.TakeTopCard());
            dealerHand.AddCard(deckOfCards.TakeTopCard());

            // Giving orders to show all the cards on player's hand
            playerHand.ShowAllCards();

            // Giving orders to show only the first card on dealer's hand
            dealerHand.ShowFirstCard();

            // Printing both hands on screen
            playerHand.Print();
            dealerHand.Print();

            // Asking the player to hit or stand
            playerHand.HitOrNot(deckOfCards);

            // Giving orders to show all the cards in both hands
            dealerHand.ShowAllCards();
            playerHand.ShowAllCards();

            // Printing both hands on screen
            playerHand.Print();
            dealerHand.Print();

            // Showing scores for both hands
            Console.WriteLine();
            Console.WriteLine("Player's Score: " + playerHand.Score.ToString());
            Console.WriteLine("Delaer's Score: " + dealerHand.Score.ToString());
        }
    }
}
