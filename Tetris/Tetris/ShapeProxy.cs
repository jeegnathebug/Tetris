using System;

namespace Tetris
{
    class ShapeProxy : IShape
    {
        private Random random;
        private IShape current;
        private IBoard board;

        public event JoinPileHandler JoinPile;

        public int Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Block this[int i]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

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
    }
}
