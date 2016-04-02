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
