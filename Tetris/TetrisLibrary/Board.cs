using System;
using System.Drawing;
using Microsoft.Xna.Framework;

namespace TetrisLibrary
{
    class Board : IBoard
    {
        #region Fields

        private Color[,] board;
        private IShape shape;
        private IShapeFactory shapeFactory;

        public event LinesClearedHandler LinesCleared;
        public event GameOverHandler GameOver;

        #endregion

        #region Properties

        public IShape Shape
        {
            get { return shape; }
        }

        public Color this[int i, int j]
        {
            get { return this[i, j]; }
        }

        #endregion

        #region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="TetrisLibrary.Board"/> class.
		/// </summary>
		/// <param name="shape">The current <see cref="Shape"/> being deployed.</param>
		/// <param name="shapeFactory">The <see cref="ShapeFactory"/>.</param>
        public Board(IShape shape, IShapeFactory shapeFactory)
        {
            board = new Color[10, 20];
            this.shape = shape;
            this.shapeFactory = shapeFactory;

            // Event handler
            shape.JoinPile += new JoinPileHandler(addToPile);
        }

        #endregion

        #region Methods

		/// <summary>
		/// Gets the length of the given rank
		/// </summary>
		/// <returns>The length of the rank.</returns>
		/// <param name="rank">The rank whose Length is to be determined.</param>
        public int GetLength(int rank)
        {
            return board.GetLength(rank);
        }

		/// <summary>
		/// Raises the lines cleared event.
		/// </summary>
		/// <param name="lines">Number of lines cleared.</param>
        protected void OnLinesCleared(int lines)
        {
            if (LinesCleared != null)
            {
                LinesCleared(lines);
            }
        }

		/// <summary>
		/// Raises the game over event.
		/// </summary>
        protected void OnGameOver()
        {
            if (GameOver != null)
            {
                GameOver();
            }
        }

		/// <summary>
		/// Adds the <see cref="Shape"/> to the pile.
		/// </summary>
		/// <param name="shape">The shape to add to the pile.</param>
        private void addToPile(IShape shape)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
