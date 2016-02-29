using System;
using Microsoft.Xna.Framework;

namespace TetrisLibrary
{
    class ShapeProxy : IShape, IShapeFactory
    {
        #region Fields

        private static Random random;
        private IShape current;
        private IBoard board;

        public event JoinPileHandler JoinPile;

        #endregion

        #region Properties

        public int Length
        {
            get { return Length; }
        }

        public Block this[int i]
        {
            get { return current[i]; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TetrisLibrary.ShapeProxy"/> class.
        /// </summary>
        /// <param name="current">The current shape.</param>
        /// <param name="board">The board being used.</param>
        public ShapeProxy(IShape current, IBoard board)
        {
            this.current = current;
            this.board = board;

            // Event handler
            // TODO What method do I need to give JoinPileHandler in ShapeProxy?
            current.JoinPile += new JoinPileHandler();
        }

        #endregion

        #region Methods

        protected void OnJoinPile()
        {
            if (JoinPile != null)
            {
                JoinPile(this);
            }
        }

        public void MoveLeft()
        {
            current.MoveLeft();
        }

        public void MoveRight()
        {
            current.MoveRight();
        }

        public void MoveDown()
        {
            current.MoveDown();
        }

        public void Drop()
        {
            current.Drop();
        }

        public void Rotate()
        {
            current.Rotate();
        }

        public void Reset()
        {
            current.Reset();
        }

        // TODO DeployNewShape() Not yet implemented
        public void DeployNewShape()
        {
            int r = random.Next(7);

            throw new NotImplementedException();
        }

        #endregion
    }
}
