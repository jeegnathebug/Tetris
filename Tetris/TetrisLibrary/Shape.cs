using System.Drawing;
using Microsoft.Xna.Framework;

namespace TetrisLibrary
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
        
        // TODO What is Length of Shape?
        public int Length
        {
            get { return Length; }
        }

        public Block this[int i]
        {
            get { return blocks[i]; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TetrisLibrary.Shape"/> class.
        /// </summary>
        public Shape()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Raises the join pile event.
        /// </summary>
        protected void OnJoinPile()
        {
            if (JoinPile != null)
            {
                JoinPile(this);
            }
        }

        /// <summary>
        /// Moves the shape left.
        /// </summary>
        public abstract void MoveLeft();

        /// <summary>
        /// Moves the shape right.
        /// </summary>
        public abstract void MoveRight();

        /// <summary>
        /// Moves the shape down.
        /// </summary>
        public abstract void MoveDown();

        // TODO Drop() Not completed
        /// <summary>
        /// Drop this shape to the top of the pile.
        /// </summary>
        public void Drop()
        {
            // MoveDown until you cannot MoveDown any further

            //while() { // while you can still MoveDown
                bool canMove = false;
                for (int i = 0; i < blocks.Length; i++)
                {
                    canMove &= blocks[i].TryMoveDown();
                }

                if (canMove)
                {
                    MoveDown();
                }
            //}

            // Fire event
            OnJoinPile();
        }

        /// <summary>
        /// Rotates this shape 90 degrees counterclockwise.
        /// </summary>
        public abstract void Rotate();

        // TODO Reset() on all shapes not yet implemented. And what is it supposed to do?
        /// <summary>
        /// Resets this instance.
        /// </summary>
        public abstract void Reset();

        #endregion
    }
}
