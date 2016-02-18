using System;

namespace Tetris
{
    class ShapeProxy : IShape, IShapeFactory
    {
        #region Fields
        private Random random;
        private IShape current;
        private IBoard board;
 
        public event JoinPileHandler JoinPile;
        #endregion

        #region Properties
        public int Length
        {
            get { throw new NotImplementedException(); }
        }

        public Block this[int i]
        {
            get{ throw new NotImplementedException(); }
        }
        #endregion

        #region Constructor
        public ShapeProxy()
        {

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

        public void DeployNewShape()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
