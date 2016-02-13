using System;
using System.Drawing;

namespace Tetris
{
    class Board : IBoard
    {
        private Color[,] board;
        private IShape shape;
        private IShapeFactory shapeFactory;

        public Color this[int i, int j]
        {
            get
            {
                return this[i, j];
            }
        }

        public IShape Shape
        {
            get
            {
                return Shape;
            }
        }

        public int GetLength(int rank)
        {
            throw new NotImplementedException();
        }

        protected void OnLinesCleared(int lines)
        {
            throw new NotImplementedException();
        }

        protected void OnGameOver()
        {
            throw new NotImplementedException();
        }

        private void addToPile(IShape shape)
        {
            throw new NotImplementedException();
        }
    }
}
