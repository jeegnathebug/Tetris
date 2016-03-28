﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TetrisLibrary;

namespace TetrisGame
{
    public class BoardSprite
    {
        private IBoard board;
        private Game game;
        private SpriteBatch spriteBatch;

        private Texture2D emptyBlock;
        private Texture2D filledBlock;

        public BoardSprite(Game game, IBoard board)
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
        public void Initialize()
        {
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected void LoadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime)
        {
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Draw(GameTime gameTime)
        {

        }
    }
}