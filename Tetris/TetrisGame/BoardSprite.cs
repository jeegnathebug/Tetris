using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TetrisLibrary;

namespace TetrisGame
{
    public class BoardSprite : DrawableGameComponent
    {
        private IBoard board;
        private Game game;
        private SpriteBatch spriteBatch;

        private Texture2D emptyBlock;
        private Texture2D filledBlock;

        public BoardSprite(Game game, IBoard board) : base(game)
        {
            this.game = game;
            this.board = board;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public override void Initialize()
        {
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
            emptyBlock = game.Content.Load<Texture2D>("EmptyBlock");
            base.LoadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(GameTime gameTime)
        {
            int size = 25;

            spriteBatch.Begin();

            for (int i = 0; i < board.GetLength(0) * size; i += size)
            {
                for (int j = 0; j < board.GetLength(1) * size; j += size)
                {
                    // Filled block
                    System.Drawing.Color c = board[i/size, j/size];
                    Texture2D block = filledBlock;

                    // Empty block
                    if (c.Equals(System.Drawing.Color.Black))
                    {
                        c = System.Drawing.Color.DarkSlateGray;
                        block = emptyBlock;
                    }

                    spriteBatch.Draw(block, new Rectangle(200 + i, 50 + j, size, size), new Color(c.R, c.G, c.B));
                }
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
