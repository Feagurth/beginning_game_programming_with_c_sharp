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

namespace Lab17
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        // Const for screen resolution
        const int WINDOW_WIDTH = 800;
        const int WINDOW_HEIGHT = 600;

        // Const for the move increment
        const int MOVE_INCREMENT = 5;

        // Const for the score text
        const string SCORE_TEXT = "Score: ";

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Variables for the background
        Texture2D car;
        Rectangle carRectangle;

        // Variables for the screen count
        SpriteFont font;
        Vector2 vectorOffScreenCount = new Vector2(WINDOW_WIDTH / 20, WINDOW_HEIGHT / 20);

        // To count the time the car goes of screen
        int offScreenCount = 0;

        // Variable to show the score
        string score = SCORE_TEXT;

        // Variable to control the off screen
        bool offScreenControl = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Setting screen resolution
            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;

            // Setting mouse visible
            IsMouseVisible = true;
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

            // Loading car sprite
            car = Content.Load<Texture2D>("Police");
            carRectangle = new Rectangle(WINDOW_WIDTH / 2 - car.Width / 8, WINDOW_HEIGHT / 2 - car.Height / 8, 
                                        car.Width / 4, car.Height / 4);

            // Loading font for the off screen score
            font = Content.Load<SpriteFont>("Arial");

            score = SCORE_TEXT + offScreenCount;
            
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

            // Getting keyboard's state
            KeyboardState keyState = Keyboard.GetState();

            
            // Moving car
            if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.NumPad6))
            {
                carRectangle.X += MOVE_INCREMENT;
            }
            if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.NumPad4))
            {
                carRectangle.X -= MOVE_INCREMENT;
            }
            if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W) || keyState.IsKeyDown(Keys.NumPad8))
            {
                carRectangle.Y -= MOVE_INCREMENT;
            }
            if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S) || keyState.IsKeyDown(Keys.NumPad2))
            {
                carRectangle.Y += MOVE_INCREMENT;
            }
            
            // Checking if the space bar is pressed
            if (keyState.IsKeyDown(Keys.Space))
            {
                // We put the car in the center of the screen again
                carRectangle.X = WINDOW_WIDTH / 2 - carRectangle.Width / 2;
                carRectangle.Y = WINDOW_HEIGHT / 2 - carRectangle.Height / 2;
            }

            // Checking if the car its outside the borders of the screen
            if (carRectangle.Right < 0 || carRectangle.Left > WINDOW_WIDTH ||carRectangle.Top < 0 || carRectangle.Bottom > WINDOW_HEIGHT)
            {
                // Checking of the car was outside the screen before entering
                if (!offScreenControl)
                {
                    // If it was outside we add one to the score
                    offScreenCount += 1;

                    // And we change the control to true to take notice the car is outside the screen
                    offScreenControl = true;

                    // We create the new string with the score
                    score = SCORE_TEXT + offScreenCount;
                }
            }
            else
            {
                // If the car isn't outside the screen, we change the variable.
                offScreenControl = false;            
            }
            


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // Drawing the car
            spriteBatch.Draw(car, carRectangle, Color.White);

            // Drawing score
            spriteBatch.DrawString(font, score, vectorOffScreenCount, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
