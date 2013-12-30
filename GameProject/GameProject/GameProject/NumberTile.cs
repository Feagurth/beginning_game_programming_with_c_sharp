using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    /// <remarks>
    /// A number tile
    /// </remarks>
    class NumberTile
    {
        #region Fields

        // Step 32
        // Whether or not this tile is visible
        bool isVisible = true;

        // Whether or not this tile is blinking
        bool isBlinking = false;

        // Whether or not this tile is shrinking
        bool isShrinking = false;
        
        // original length of each side of the tile
        int originalSideLength;

        // Step 36
        // Constant to store total miliseconds to shrink a tile
        const int TOTAL_SHRINK_MILLISECONDS = 1000;

        // Variable to store the elapsed miliseconds 
        int elapsedShrinkMilliseconds = 0;

        // Step 33
        // Click support variables
        bool clickStarted= false;
        bool buttonReleased = true;

        // whether or not this tile is the correct number
        bool isCorrectNumber;

        // drawing support
        Texture2D texture;
        Rectangle drawRectangle;
        Rectangle sourceRectangle;

        // Step 40
        // Blinking tile
        Texture2D blinkingTile;

        // Step 42
        // Textute for drawing the tile
        Texture2D drawingTile;

        // blinking support
        const int TOTAL_BLINK_MILLISECONDS = 4000;
        int elapsedBlinkMilliseconds = 0;
        const int FRAME_BLINK_MILLISECONDS = 1000;
        int elapsedFrameMilliseconds = 0;

        // Step 66
        // Declaring a field to hold the sound bank
        SoundBank soundBank;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="contentManager">the content manager</param>
        /// <param name="center">the center of the tile</param>
        /// <param name="sideLength">the side length for the tile</param>
        /// <param name="number">the number for the tile</param>
        /// <param name="correctNumber">the correct number</param>
        /// <param name="soundBank">the sound bank for playing cues</param>
        public NumberTile(ContentManager contentManager, Vector2 center, int sideLength,
            int number, int correctNumber, SoundBank soundBank)
        {
            // set original side length field
            this.originalSideLength = sideLength;

            // Step 67
            // Set sound bank field
            this.soundBank = soundBank;            

            // load content for the tile and create draw rectangle
            LoadContent(contentManager, number);
            drawRectangle = new Rectangle((int)center.X - sideLength / 2,
                 (int)center.Y - sideLength / 2, sideLength, sideLength);

            // set isCorrectNumber flag
            isCorrectNumber = number == correctNumber;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Updates the tile based on game time and mouse state
        /// </summary>
        /// <param name="gameTime">the current GameTime</param>
        /// <param name="mouse">the current mouse state</param>
        /// <return>true if the correct number was guessed, false otherwise</return>
        public bool Update(GameTime gameTime, MouseState mouse)
        {
            // highlighting tile
            // Step 31
            if (drawRectangle.Contains(mouse.X, mouse.Y))
            {
                // Step 33
                // Check for click started on button
                if (mouse.LeftButton == ButtonState.Pressed &&
                    buttonReleased)
                {
                    clickStarted = true;
                    buttonReleased = false;
                }
                else if (mouse.LeftButton == ButtonState.Released)
                {
                    buttonReleased = true;

                    // if click finished on button, change game state
                    if (clickStarted)
                    {
                        if (isCorrectNumber)
                        {
                            isBlinking = true;

                            // Step 68
                            // Playing correct guess sound
                            soundBank.PlayCue("correctGuess");

                            // Step 45
                            // Setting drawing tile to the blinking tile
                            drawingTile = blinkingTile;

                            // Setting source rectangle's X to zero
                            sourceRectangle.X = 0;
                        }
                        else
                        {
                            isShrinking = true;

                            // Step 68
                            // Playing incorrect guess sound
                            soundBank.PlayCue("incorrectGuess");
                        }

                        clickStarted = false;
                    }
                }
            }
            else
            {
                //sourceRectangle.X = 0;
                // no clicking on this button
                clickStarted = false;
                buttonReleased = false;
            }

            if (isShrinking)
            {
                // Step 37
                // Adding elapsed game time
                elapsedShrinkMilliseconds += gameTime.ElapsedGameTime.Milliseconds;

                // Moving the draw rectangle in x and y axis the new size of the draw rectangle divided by 2 since the draw rectangle is double of the size of the tile
                drawRectangle.X += (drawRectangle.Width - (int)(originalSideLength * ((float)(TOTAL_SHRINK_MILLISECONDS - elapsedShrinkMilliseconds) / (float)TOTAL_SHRINK_MILLISECONDS))) / 2;
                drawRectangle.Y += (drawRectangle.Height - (int)(originalSideLength * ((float)(TOTAL_SHRINK_MILLISECONDS - elapsedShrinkMilliseconds) / (float)TOTAL_SHRINK_MILLISECONDS))) / 2;

                // Calculating new size of the draw rectangle
                drawRectangle.Width = (int)(originalSideLength * ((float)(TOTAL_SHRINK_MILLISECONDS - elapsedShrinkMilliseconds) / (float)TOTAL_SHRINK_MILLISECONDS));
                drawRectangle.Height = (int)(originalSideLength * ((float)(TOTAL_SHRINK_MILLISECONDS - elapsedShrinkMilliseconds) / (float)TOTAL_SHRINK_MILLISECONDS));
                
                // If the width of the drawrectangle is 0, make it not visible
                if (drawRectangle.Width <= 0)
                {
                    isVisible = false;
                }
            }
            // Step 46
            else if (isBlinking)
            {
                // Step 48
                // Adding game time to the variable to control the blinking should stop
                elapsedBlinkMilliseconds += gameTime.ElapsedGameTime.Milliseconds;
                
                // Step 49
                // Adding game time to the variable to control the blinking
                elapsedFrameMilliseconds += gameTime.ElapsedGameTime.Milliseconds;

                // Checking if the time elapsed is greater than the const for changing the blinking
                if (elapsedFrameMilliseconds >= FRAME_BLINK_MILLISECONDS)
                {
                    // Resetting the variable wich controls the blinking
                    elapsedFrameMilliseconds = 0;

                    // Doing the blinking
                    if (sourceRectangle.X == 0)
                    {
                        // Moving the source rectangle to the middle of the blinking tile
                        sourceRectangle.X = texture.Width / 2;
                    }
                    else
                    {
                        // Moving the source rectangle at the begining of the blinking tile
                        sourceRectangle.X = 0;
                    }
                }

                // Checking if we are done with the blinking to make the tile invisible
                if (elapsedBlinkMilliseconds == TOTAL_BLINK_MILLISECONDS)
                {
                    // Step 57
                    // Returning true instead of putting the tile invisible
                    //isVisible = false;
                    return true;
                }
            }
            else
            {
                // Step 38
                // If the tile is not shrinking we can change the color of it on moving 
                // the mouse over it
                if (drawRectangle.Contains(mouse.X, mouse.Y))
                {
                    sourceRectangle.X = texture.Width / 2;
                }
                else
                {
                    sourceRectangle.X = 0;
                }
            }

            // if we get here, return false
            return false;
        }

        /// <summary>
        /// Draws the number tile
        /// </summary>
        /// <param name="spriteBatch">the SpriteBatch to use for the drawing</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // Step 35
            // Drawing the tile only if it's visible
            if (isVisible)
            {
                // draw the tile
                // Step 25
                //spriteBatch.Draw(texture, drawRectangle, sourceRectangle, Color.White);

                // Step 44
                // Changing to draw the drawing tile
                spriteBatch.Draw(drawingTile, drawRectangle, sourceRectangle, Color.White);
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Loads the content for the tile
        /// </summary>
        /// <param name="contentManager">the content manager</param>
        /// <param name="number">the tile number</param>
        private void LoadContent(ContentManager contentManager, int number)
        {
            // convert the number to a string
            string numberString = ConvertIntToString(number);

            // load content for the tile and set source rectangle
            // Step 22
            texture = contentManager.Load<Texture2D>(ConvertIntToString(number));

            // Setting source rectangle
            sourceRectangle = new Rectangle(0, 0, texture.Width / 2, texture.Height);

            // Step 41
            // Loading the blinking tile
            blinkingTile = contentManager.Load<Texture2D>("blinking" + ConvertIntToString(number));

            // Step 43
            // Setting the drawing textute tile to the non blinking one
            drawingTile = texture;
        }

        /// <summary>
        /// Converts an integer to a string for the corresponding number
        /// </summary>
        /// <param name="number">the integer to convert</param>
        /// <returns>the string for the corresponding number</returns>
        private String ConvertIntToString(int number)
        {
            switch (number)
            {
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    throw new Exception("Unsupported number for number tile");
            }
        }

        #endregion
    }
}
