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
using ExplodingTeddies;

namespace lab12
{
    /// <summary>
    /// Exploding teddy bears...!!!
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        const int WINDOW_WIDTH = 800;
        const int WINDOW_HEIGHT = 600;

        // Defining variables
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Teddy and explosion variables
        TeddyBear teddyBear;
        Explosion explosion;
        Random random = new Random();

        // Suport variables for pushing buttons controls
        bool controlA = false;
        bool controlB = false;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;

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

            // Creating teddybear and explosion objects
            teddyBear = new TeddyBear(Content, WINDOW_WIDTH, WINDOW_HEIGHT, "teddybear", random.Next(WINDOW_WIDTH), random.Next(WINDOW_HEIGHT), new Vector2(random.Next(5), random.Next(5)));
            explosion = new Explosion(Content);
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

            // Creating objects to control keyboard and mouse
            MouseState mouse = Mouse.GetState();
            KeyboardState keyboard = Keyboard.GetState();

            // Updating teddybear and explosion oobjects
            teddyBear.Update();
            explosion.Update(gameTime);

            
            // Checking if the mouse is over the teddybear, the left mouse button is pressed and the teddybear is active
            if (teddyBear.Active && teddyBear.DrawRectangle.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                // If so, we deactivate the teddy bear and play the explosion on the center of the teddy
                teddyBear.Active = false;
                explosion.Play(teddyBear.DrawRectangle.Center.X, teddyBear.DrawRectangle.Center.Y);
            }


            // We check if the b key on the keyboard is pushed
            if (keyboard.IsKeyDown(Keys.B))
            {
                // If so, we set the control variable to true
                controlB = true;
            }

            // We check if the b key is released and was pushed before
            if(keyboard.IsKeyUp(Keys.B) && controlB)
            {
                // If so, we do what we wantm in this case, creating a new teddy bear object
                teddyBear = new TeddyBear(Content, WINDOW_WIDTH, WINDOW_HEIGHT, "teddybear", random.Next(WINDOW_WIDTH), random.Next(WINDOW_HEIGHT), new Vector2(random.Next(5), random.Next(5)));
                // And set the control variable to false again
                controlB = false;
            }

            // Same as aboce
            if (keyboard.IsKeyDown(Keys.A))
            {
                controlA = true;
            }

            if (keyboard.IsKeyUp(Keys.A) && controlA)
            {
                // We deactivate the teddy, play the explosion and create a new teddy
                teddyBear.Active = false;
                explosion.Play(teddyBear.DrawRectangle.Center.X, teddyBear.DrawRectangle.Center.Y);
                teddyBear = new TeddyBear(Content, WINDOW_WIDTH, WINDOW_HEIGHT, "teddybear", random.Next(WINDOW_WIDTH), random.Next(WINDOW_HEIGHT), new Vector2(random.Next(5), random.Next(5)));
                controlA = false;
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

            // Drawing objects
            spriteBatch.Begin();

            teddyBear.Draw(spriteBatch);
            explosion.Draw(spriteBatch);

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
