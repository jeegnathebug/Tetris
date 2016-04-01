using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TetrisLibrary;

namespace TetrisGame
{
    public class ShapeSprite : DrawableGameComponent
    {
        private IShape shape;
        private Score score;

        // to move the shape down
        private int counterMoveDown;

        // the keyboard's last pressed key
        private KeyboardState oldState;
        // the time elapsed of the key press
        private int counterInput;
        //
        private int threshold;

        private Game game;
        private SpriteBatch spriteBatch;

        private Texture2D filledBlock;

        public ShapeSprite(Game game, IBoard board, Score score) : base(game)
        {
            this.game = game;
            this.score = score;
            shape = board.Shape;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public override void Initialize()
        {
            oldState = Keyboard.GetState();
            threshold = 30; // TODO: WAT?

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            filledBlock = game.Content.Load<Texture2D>("FilledBlock");
            base.LoadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            checkInput();

            int dropDelay = (11 - score.Level) * 5;
            if (counterMoveDown == dropDelay)
            {
                shape.MoveDown();
                counterMoveDown = 0;
            }
            else
            {
                counterMoveDown++;
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(GameTime gameTime)
        {
            int size = 25;
            spriteBatch.Begin();
            for (int i = 0; i < shape.Length; i++)
            {
                System.Drawing.Color c = shape[i].Color;
                spriteBatch.Draw(filledBlock, new Vector2(200 + shape[i].Position.X * size, 50 + shape[i].Position.Y * size), new Color(c.R, c.G, c.B));
            }
            spriteBatch.End();
        }

        private void checkInput()
        {
            KeyboardState newState = Keyboard.GetState();

            // if right key is pressed
            if (newState.IsKeyDown(Keys.Right))
            { // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.Right))
                {
                    shape.MoveRight();
                    counterInput = 0; //reset counter with every new keystroke
                }
                else {
                    counterInput++;
                    if (counterInput > threshold)
                    {
                        shape.MoveRight();
                    }
                }
            }

            // if left key is pressed
            if (newState.IsKeyDown(Keys.Left))
            { // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.Left))
                {
                    shape.MoveLeft();
                    counterInput = 0; //reset counter with every new keystroke
                }
                else {
                    counterInput++;
                    if (counterInput > threshold)
                    {
                        shape.MoveLeft();
                    }
                }
            }

            // if down key is pressed
            if (newState.IsKeyDown(Keys.Down))
            { // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.Down))
                {
                    shape.Drop();
                    counterInput = 0; //reset counter with every new keystroke
                }
                else {
                    counterInput++;
                    if (counterInput > threshold)
                    {
                        shape.Drop();
                    }
                }
            }

            if (newState.IsKeyDown(Keys.RightShift))
            { // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.RightShift))
                {
                    shape.Rotate();
                    counterInput = 0; //reset counter with every new keystroke
                }
                else {
                    counterInput++;
                    if (counterInput > threshold)
                    {
                        shape.Rotate();
                    }
                }
            }

            oldState = newState;
        }
    }
}
