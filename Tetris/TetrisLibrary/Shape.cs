using System.Drawing;

namespace TetrisLibrary
{
    public abstract class Shape : IShape
    {
        #region Fields

        private IBoard board;
        private int length;

        protected Block[] blocks;
        protected Point[][] rotationOffset;

        protected int currentRotation;

        public event JoinPileHandler JoinPile;

        #endregion

        #region Properties

        public int Length
        {
            get { return length; }
        }

        public Block this[int i]
        {
            get { return blocks[i]; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// </summary>
        public Shape()
        {
            length = 4;
        }

        #endregion

        #region Methods

        /// <summary>
		/// Drop this <see cref="Shape"/> to the top of the pile.
        /// </summary>
        public void Drop()
        {
            bool canMove = true;

            while (canMove)
            {
                // Check if each block can move down
                for (int i = 0; i < blocks.Length; i++)
                {
                    canMove &= blocks[i].TryMoveDown();
                }

                // If they can, move down
                if (canMove)
                {
                    MoveDown();
                }
            }

            // Fire event
            OnJoinPile();
        }

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
		/// Moves this <see cref="Shape"/> left.
        /// </summary>
        public void MoveLeft()
        {
            bool canMove = true;

            // Checks whether or not each block can move
            foreach (Block b in blocks)
            {
                canMove &= b.TryMoveLeft();
            }

            // Moves each block
            if (canMove)
            {
                foreach (Block b in blocks)
                {
                    b.MoveLeft();
                }
            }
        }

        /// <summary>
		/// Moves this <see cref="Shape"/> right.
        /// </summary>
        public void MoveRight()
        {
            bool canMove = true;

            // Checks whether or not each block can move
            foreach (Block b in blocks)
            {
                canMove &= b.TryMoveRight();
            }

            // Moves each block
            if (canMove)
            {
                foreach (Block b in blocks)
                {
                    b.MoveRight();
                }
            }
        }

        /// <summary>
		/// Moves this <see cref="Shape"/> down.
        /// </summary>
        public void MoveDown()
        {
            bool canMove = true;

            // Checks whether or not each block can move
            foreach (Block b in blocks)
            {
                canMove &= b.TryMoveDown();
            }

            // Moves each block
            if (canMove)
            {
                foreach (Block b in blocks)
                {
                    b.MoveDown();
                }
            } else
            // It as joined the pile. Fire event
            {
                OnJoinPile();
            }
        }

        /// <summary>
		/// Rotates this <see cref="Shape"/> 90 degrees counterclockwise.
        /// </summary>
        public void Rotate()
        {
            // Rotate only if currentRotation is not -1. Only used for ShapeO
			if (currentRotation != -1) {

                int newRotation;

                if (currentRotation == rotationOffset[0].Length - 1)
                {
                    newRotation = 0;
                } else
                {
                    newRotation = currentRotation++;
                }

				bool canRotate = true;

				// Checks whether or not each block can move
				for (int i = 0; i < blocks.Length; i++) {
					canRotate &= blocks[i].TryRotate(rotationOffset[i][newRotation]);
				}

				if (canRotate) {
					// Rotate each block
					for (int i = 0; i < blocks.Length; i++) {
						blocks[i].Rotate(rotationOffset[i][newRotation]);
					}

                    // Update current rotation
                    currentRotation = newRotation;
                }
			}
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public void Reset()
        {
            // Reset rotation
            currentRotation = 0;

            // Reset block locations
            setBlockPositions();
        }

        protected abstract void setBlockPositions();
        #endregion
    }
}
