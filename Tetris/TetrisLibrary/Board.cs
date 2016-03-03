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

        public int GetLength(int rank)
        {
            return board.GetLength(rank);
        }

        protected void OnLinesCleared(int lines)
        {
            if (LinesCleared != null)
            {
                LinesCleared(lines);
            }
        }

        protected void OnGameOver()
        {
            if (GameOver != null)
            {
                GameOver();
            }
        }

        private void addToPile(IShape shape)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
