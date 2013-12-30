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

namespace Lab5
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        const int WINDOW_WIDTH = 800;
        const int WINDOW_HEIGHT = 600;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Creating variables for the content
        Texture2D car0;
        Texture2D car1;
        Texture2D car2;


        // Creating Rectangles to draw the content
        Rectangle drawRectangle0;
        Rectangle drawRectangle1;
        Rectangle drawRectangle2;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            // Setting windows size
            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;

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

            // Loading Content
            car0 = Content.Load<Texture2D>("car0");
            car1 = Content.Load<Texture2D>("car1");
            car2 = Content.Load<Texture2D>("car2");

            
            // Setting DrawRectangles
            drawRectangle0.X = 100;
            drawRectangle0.Y = 100;
            drawRectangle0.Height = car0.Height;
            drawRectangle0.Width = car0.Width;

            drawRectangle1.X = 400;
            drawRectangle1.Y = 200;
            drawRectangle1.Height = car1.Height;
            drawRectangle1.Width = car1.Width;

            drawRectangle2.X = 600;
            drawRectangle2.Y = 300;
            drawRectangle2.Height = car2.Height;
            drawRectangle2.Width = car2.Width;
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

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            // Drawing sprites
            spriteBatch.Begin();

            spriteBatch.Draw(car0, drawRectangle0, Color.White);
            spriteBatch.Draw(car1, drawRectangle1, Color.White);
            spriteBatch.Draw(car2, drawRectangle2, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
