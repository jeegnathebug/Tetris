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
            threshold = 30;

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

            // use counterMoveDown and number determined by level
            if (gameTime.ElapsedGameTime.Milliseconds == counterMoveDown)
            {
                shape.Drop();
            }
            else
            {
                counterMoveDown--;
            }
            // Note: this method is called every 1/60th of a second
            // dropDelay = (11 - level) * 0.05 seconds
            //In other words, at level 1, the shape will drop at every ½
            //second, increasing at every level by 0.05 seconds, or 1/20
            //of a second.Since the maximum level is 10, the quickest that
            //the shape will move down is every 1 / 20 of a second.The game
            //loop iterates at every 1 / 60 of a second, so you will need to
            //use a threshold in your Update method to throttle how often you
            //ask the shape to move down.
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            for (int i = 0; i < shape.Length; i++)
            {
                System.Drawing.Color c = shape[i].Color;
                spriteBatch.Draw(filledBlock, new Vector2(shape[i].Position.X, shape[i].Position.Y), new Color(c.R, c.G, c.B));
            }
            spriteBatch.End();
        }

        private void checkInput()
        {
            KeyboardState newState = Keyboard.GetState();

            // if right key is pressed
            if (newState.IsKeyDown(Keys.Right))
            {
                shape.MoveRight();
            }

            // if left key is pressed
            if (newState.IsKeyDown(Keys.Left))
            {
                shape.MoveLeft();
            }

            // if down key is pressed
            if (newState.IsKeyDown(Keys.Right))
            {
                shape.Drop();
            }
        }
    }
}
