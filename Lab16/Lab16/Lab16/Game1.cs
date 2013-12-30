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

namespace Lab16
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        const int WINDOW_WIDTH = 800;
        const int WINDOW_HEIGHT = 600;

        // Objects for playing audio
        AudioEngine audioEngine;
        WaveBank waveBank;
        SoundBank soundBank;

        // Click control
        bool mouseClicked = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Adjusting window's size
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

            // Loading audio
            audioEngine = new AudioEngine(@"Content\Lab16Audio.xgs");
            waveBank = new WaveBank(audioEngine,@"Content\Wave Bank.xwb");
            soundBank = new SoundBank(audioEngine,@"Content\Sound Bank.xsb");

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

            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed && !mouseClicked)
            {
                mouseClicked = true;
            }
            else if (mouseState.LeftButton== ButtonState.Released && mouseClicked)
            {
                mouseClicked = false;

                // Checking mouse position
                // Is the mouse in the right side of the screen..,?
                if (mouseState.X >= WINDOW_WIDTH / 2)
                {
                    // Is on the right
                    // Is the mouse on the upper side of the screen...?
                    if (mouseState.Y <= WINDOW_HEIGHT / 2)
                    {
                        // Is on the upper side
                        soundBank.PlayCue("upperRight");

                    }
                    else
                    {
                        // Is on the lower side
                        soundBank.PlayCue("lowerRight");
                    }
                }
                else
                {
                    // Is on the left
                    // Is the mouse on the upper side of the screen...?
                    if (mouseState.Y <= WINDOW_HEIGHT / 2)
                    {
                        // Is on the upper side
                        soundBank.PlayCue("upperLeft");

                    }
                    else
                    {
                        // Is on the lower side
                        soundBank.PlayCue("lowerLeft");

                    }
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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
