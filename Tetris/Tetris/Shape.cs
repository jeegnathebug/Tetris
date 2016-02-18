using System;
using System.Drawing;

namespace Tetris
{
    abstract class Shape : IShape
    {
        #region Fields
        private IBoard board;
        protected Block[] blocks;
        protected Point[][] rotationOffset;
        protected int currentRotation;

        public event JoinPileHandler JoinPile;
        #endregion

        #region Properties
        public int Length
        {
            get{throw new NotImplementedException();}
        }

        public Block this[int i]
        {
            get{throw new NotImplementedException();}
        }
        #endregion

        #region Methods
        protected void OnJoinPile()
        {
            throw new NotImplementedException();
        }

        public void MoveLeft()
        {
            throw new NotImplementedException();
        }

        public void MoveRight()
        {
            throw new NotImplementedException();
        }

        public void MoveDown()
        {
            throw new NotImplementedException();
        }

        public void Drop()
        {
            throw new NotImplementedException();
        }

        public void Rotate()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
