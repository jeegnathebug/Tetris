using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using TetrisLibrary;

namespace TetrisGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        #region Button 
        enum BState
        {
            HOVER,
            UP,
            JUST_RELEASED,
            DOWN
        }
        Color background_color;
        Color button_color = new Color();
        Rectangle button_rectangle = new Rectangle();
        BState button_state = new BState();
        Texture2D[] button_texture = new Texture2D[1];
        double button_timer;
        //mouse pressed and mouse just pressed
        bool mpressed, prev_mpressed = false;
        int mx, my;
        double frame_time;
        #endregion

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private BoardSprite boardSprite;
        private ShapeSprite shapeSprite;
        private ScoreSprite scoreSprite;

        private SpriteFont font;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 400;
            graphics.PreferredBackBufferWidth = 300;

            Window.Title = "Tetris";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Instantiate Tetris logic
            IBoard board = new Board();
            Score score = new Score(board);

            // Add to board's GameOver event
            board.GameOver += gameOver;

            // Instantiate sprite classes
            int size = 25;
            boardSprite = new BoardSprite(this, board, size);
            shapeSprite = new ShapeSprite(this, board, score, size);
            scoreSprite = new ScoreSprite(this, score);

            // Add sprite classes
            Components.Add(boardSprite);
            Components.Add(shapeSprite);
            Components.Add(scoreSprite);

            // Set height and width of screen
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 500;
            graphics.ApplyChanges();

            // Initialize font
            font = Content.Load<SpriteFont>("scoreFont");

            base.Initialize();

            //Create button
            int x = 5;
            int y = 200;
            button_state = BState.UP;
            button_color = Color.White;
            button_timer = 0.0;
            button_rectangle = new Rectangle(x, y, 100, 40);
            IsMouseVisible = true;

            background_color = Color.Black;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Button
            button_texture[0] =
                Content.Load<Texture2D>("restart");
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Press F5 to restart game. It's like hitting refresh
            if (Keyboard.GetState().IsKeyDown(Keys.F5))
                RestartGame();

            // get elapsed frame time in seconds
            frame_time = gameTime.ElapsedGameTime.Milliseconds / 1000.0;

            // update mouse variables
            MouseState mouse_state = Mouse.GetState();
            mx = mouse_state.X;
            my = mouse_state.Y;
            prev_mpressed = mpressed;
            mpressed = mouse_state.LeftButton == ButtonState.Pressed;

            UpdateButtons();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(background_color);

            spriteBatch.Begin();
            // Draw button
            spriteBatch.Draw(button_texture[0], button_rectangle, button_color);
            // Draw instructions
            string instructions = "Left arrow:" + Environment.NewLine + "move shape left" + Environment.NewLine + Environment.NewLine + "Right arrow:" + Environment.NewLine + "move shape right" + Environment.NewLine + Environment.NewLine + "Down arrow:" + Environment.NewLine + "move shape down" + Environment.NewLine + Environment.NewLine + "Right shift:" + Environment.NewLine + "rotate shape";
            spriteBatch.DrawString(font, instructions, new Vector2(5, 300), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Ends the game
        /// </summary>
        private void gameOver()
        {
            Components.Remove(shapeSprite);
            scoreSprite.endGame();
        }


        /// <summary>
        /// Wrapper for hit_image_alpha taking Rectangle and Texture
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="tex"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        bool HitImage(Rectangle rect, Texture2D tex, int x, int y)
        {
            return HitImage(0, 0, tex, tex.Width * (x - rect.X) /
                rect.Width, tex.Height * (y - rect.Y) / rect.Height);
        }

        /// <summary>
        /// Wraps hit_image then determines if hit a transparent part of image 
        /// </summary>
        /// <param name="tx"></param>
        /// <param name="ty"></param>
        /// <param name="tex"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        bool HitImage(float tx, float ty, Texture2D tex, int x, int y)
        {
            if (ValidateButtonXY(tx, ty, tex, x, y))
            {
                uint[] data = new uint[tex.Width * tex.Height];
                tex.GetData<uint>(data);
                if ((x - (int)tx) + (y - (int)ty) *
                    tex.Width < tex.Width * tex.Height)
                {
                    return ((data[
                        (x - (int)tx) + (y - (int)ty) * tex.Width
                        ] &
                                0xFF000000) >> 24) > 20;
                }
            }
            return false;
        }
        /// <summary>
        /// Determine if x,y is within rectangle formed by texture located at tx,ty
        /// </summary>
        /// <param name="tx"></param>
        /// <param name="ty"></param>
        /// <param name="tex"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        bool ValidateButtonXY(float tx, float ty, Texture2D tex, int x, int y)
        {
            return (x >= tx &&
                x <= tx + tex.Width &&
                y >= ty &&
                y <= ty + tex.Height);
        }

        /// <summary>
        /// Determine state and color of button
        /// </summary>
        void UpdateButtons()
        {
            if (HitImage(button_rectangle, button_texture[0], mx, my))
            {
                button_timer = 0.0;
                if (mpressed)
                {
                    // mouse is currently down
                    button_state = BState.DOWN;
                    button_color = Color.Blue;
                }
                else if (!mpressed && prev_mpressed)
                {
                    // mouse was just released
                    if (button_state == BState.DOWN)
                    {
                        // button i was just down
                        button_state = BState.JUST_RELEASED;
                    }
                }
                else
                {
                    button_state = BState.HOVER;
                    button_color = Color.LightBlue;
                }
            }
            else
            {
                button_state = BState.UP;
                if (button_timer > 0)
                {
                    button_timer = button_timer - frame_time;
                }
                else
                {
                    button_color = Color.White;
                }
            }
            if (button_state == BState.JUST_RELEASED)
            {
                RestartGame();
            }
        }

        /// <summary>
        /// Restarts the game
        /// </summary> 
        public void RestartGame()
        {
            Exit();
            Game1 game = new Game1();
            game.Run();
        }
    }
}
