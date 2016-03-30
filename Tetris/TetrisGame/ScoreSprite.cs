using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TetrisLibrary;

namespace TetrisGame
{
    public class ScoreSprite : DrawableGameComponent
    {
        private Score score;

        private Game game;
        private SpriteBatch spriteBatch;

        private SpriteFont font;

        public ScoreSprite(Game game, Score score) : base(game)
        {
            this.game = game;
            this.score = score;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = game.Content.Load<SpriteFont>("scoreFont");

            base.LoadContent();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Score: " + score.score, new Vector2(0, 0), Color.White);
            spriteBatch.End();
        }
    }
}
