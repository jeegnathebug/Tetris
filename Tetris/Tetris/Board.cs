﻿using System;
using System.Drawing;

namespace Tetris
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
        public Color this[int i, int j]
        {
            get{return this[i, j];}
        }

        public IShape Shape
        {
            get{return Shape;}
        }
        #endregion

        #region Constructor
        public Board()
        {

        }
        #endregion

        #region Methods
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
        #endregion
    }
}
