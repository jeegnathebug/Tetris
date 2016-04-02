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

        private bool isGameOver = false;
        string time = "00:00";

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
            // Stop updating time if game is over
            if (!isGameOver)
            {
                int minutes = gameTime.TotalGameTime.Minutes;
                int seconds = gameTime.TotalGameTime.Seconds;
                time = (minutes < 10 ? "0" + minutes : "" + minutes) + ":" + (seconds < 10 ? "0" + seconds : "" + seconds);
            }
            else
            {
                spriteBatch.DrawString(font, "Game Over", new Vector2(250, 10), Color.White);
            }
            spriteBatch.DrawString(font, "Score: " + score.score, new Vector2(5, 5), Color.White);
            spriteBatch.DrawString(font, "Level: " + score.Level, new Vector2(5, 30), Color.White);
            spriteBatch.DrawString(font, "Lines: " + score.Lines, new Vector2(5, 55), Color.White);
            spriteBatch.DrawString(font, "Time: " + time, new Vector2(5, 100), Color.White);
            spriteBatch.End();
        }

        /// <summary>
        /// Tells ScoreSprite the game has ended
        /// </summary>
        public void endGame()
        {
            isGameOver = true;

        }
    }
}
