using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using XnaCards;

namespace ProgrammingAssignment6
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Const for graphic resolution
        const int SCREEN_WIDTH = 800;
        const int SCREEN_HEIGHT = 600;
        
        // Deck for the game
        Deck deck;

        // Hands for both players
        WarHand playerHand;
        WarHand computerHand;

        // Pile for both players
        WarBattlePile playerPile;
        WarBattlePile computerPile;
        
        // Keep track of game state and current winner
        static GameState gameState = GameState.Play;

        // Winner messages for players
        WinnerMessage playerMessage;
        WinnerMessage computerMessage;

        // Menu buttons
        MenuButton flipButton;
        MenuButton quitButton;
        MenuButton collectButton;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Mouse visible
            IsMouseVisible = true;

            // Setting resolution
            graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;
            graphics.PreferredBackBufferWidth = SCREEN_WIDTH;

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Create the deck object and shuffle
            deck = new Deck(Content, 100, 100);
            deck.Shuffle();

            // Create the player hands and fully deal the deck into the hands
            playerHand = new WarHand(SCREEN_WIDTH / 2, 100);
            computerHand = new WarHand(SCREEN_WIDTH / 2, SCREEN_HEIGHT - 100);

            // Dealing cards
            while (!deck.Empty)
            {
                playerHand.AddCard(deck.TakeTopCard());
                computerHand.AddCard(deck.TakeTopCard());
            }

            // Create the player battle piles
            playerPile = new WarBattlePile(SCREEN_WIDTH / 2, 250);
            computerPile = new WarBattlePile(SCREEN_WIDTH / 2, SCREEN_HEIGHT - 250);

            // Create the player winner messages
            playerMessage = new WinnerMessage(Content, (7 * (SCREEN_WIDTH / 10)), 100);
            computerMessage = new WinnerMessage(Content, (7 * (SCREEN_WIDTH / 10)), SCREEN_HEIGHT - 100);

            // Create the menu buttons
            flipButton = new MenuButton(Content, "flipbutton", SCREEN_WIDTH / 5, 100, GameState.Flip);
            quitButton = new MenuButton(Content, "quitbutton", SCREEN_WIDTH / 5, 500, GameState.Quit);
            collectButton = new MenuButton(Content, "collectwinningsbutton", SCREEN_WIDTH / 5, 300, GameState.CollectWinnings);
            
            // Making collect winnings button invisible
            collectButton.Visible = false;

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            MouseState mouse = Mouse.GetState();

            // Update the menu buttons
            flipButton.Update(mouse);
            quitButton.Update(mouse);
            collectButton.Update(mouse);
 
            // Update based on game state           

            // Exiting the game
            if (gameState == GameState.Quit)
            {
                Exit();
            }

            // Flipping cards
            if (gameState == GameState.Flip)
            {
                // Putting cards on top of each pile
                playerPile.AddCard(playerHand.TakeTopCard());
                computerPile.AddCard(computerHand.TakeTopCard());

                // Flipping over the cards
                playerPile.GetTopCard().FlipOver();
                computerPile.GetTopCard().FlipOver();

                // Showing/hiding buttons
                flipButton.Visible = false;
                collectButton.Visible = true;

                // Changing game state
                ChangeState(GameState.Play);

                // Drawing winner message
                if (playerPile.GetTopCard().WarValue > computerPile.GetTopCard().WarValue)
                {
                    playerMessage.Visible = true;
                }
                else if (playerPile.GetTopCard().WarValue < computerPile.GetTopCard().WarValue)
                {
                    computerMessage.Visible = true;
                }
            }

            // Collecting winnings
            if (gameState == GameState.CollectWinnings)
            {
                // Showing/hiding buttons
                collectButton.Visible = false;
                flipButton.Visible = true;

                // Changing the game state
                ChangeState(GameState.Play);

                // If the player wons, we put all the cards from the piles to the player's hand
                if (playerPile.GetTopCard().WarValue > computerPile.GetTopCard().WarValue)
                {
                    // Taking cards from piles
                    playerHand.AddCards(playerPile);
                    playerHand.AddCards(computerPile);

                    // Hiding winning message
                    playerMessage.Visible = false;
                }
                else
                {
                    // If the player didn't win, we check if the computer win, if not, it's a tie
                    if (playerPile.GetTopCard().WarValue < computerPile.GetTopCard().WarValue)
                    {
                        // Taking cards from piles
                        computerHand.AddCards(computerPile);
                        computerHand.AddCards(playerPile);

                        // Hiding winning message
                        computerMessage.Visible = false;
                    }
                    else
                    {
                        // Player takes the cards from the pile to the hand
                        playerHand.AddCards(playerPile);

                        // Computer takes the cards from the pile to the hand
                        computerHand.AddCards(computerPile);
                    }
                }

                // If any of the hads is empty after collecting it's game over
                if (playerHand.Empty || computerHand.Empty)
                {
                    ChangeState(GameState.GameOver);
                }
            }

            // Game Over
            if (gameState == GameState.GameOver)
            {
                // Showing/hiding butttons
                flipButton.Visible = false;
                collectButton.Visible = false;
                quitButton.Visible = true;

                // If the player's hand it's empty, the computer wins
                // if not, the player wins
                if (playerHand.Empty)
                {
                    computerMessage.Visible = true;
                }
                else 
                {
                    playerMessage.Visible = true;
                }
            }
 
            base.Update(gameTime);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Goldenrod);

            spriteBatch.Begin();

            // Draw the game objects
            // Drawing the deck
            deck.Draw(spriteBatch);

            // Drawing the hands
            playerHand.Draw(spriteBatch);
            computerHand.Draw(spriteBatch);

            // Drawing the war piles
            playerPile.Draw(spriteBatch);
            computerPile.Draw(spriteBatch);

            // Draw the winner messages
            playerMessage.Draw(spriteBatch);
            computerMessage.Draw(spriteBatch);
 
            // Draw the menu buttons
            flipButton.Draw(spriteBatch);
            quitButton.Draw(spriteBatch);
            collectButton.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Changes the state of the game
        /// </summary>
        /// <param name="newState">the new game state</param>
        public static void ChangeState(GameState newState)
        {
            gameState = newState;
        }
    }
}
