using System;

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
        /// Initializes a new instance of the <see cref="ShapeProxy"/> class.
        /// </summary>
        /// <param name="current">The current shape.</param>
        /// <param name="board">The board.</param>
        public ShapeProxy(IShape current, IBoard board)
        {
            this.current = current;
            this.board = board;

            // Event handler
            // TODO What method do I need to give JoinPileHandler in ShapeProxy?
            current.JoinPile += new JoinPileHandler(board.addToPile); // But it's private :c
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
		/// Moves the <see cref="Shape"/> left.
		/// </summary>
        public void MoveLeft()
        {
            current.MoveLeft();
        }

		/// <summary>
		/// Moves the <see cref="Shape"/> right.
		/// </summary>
        public void MoveRight()
        {
            current.MoveRight();
        }

		/// <summary>
		/// Moves the <see cref="Shape"/> down.
		/// </summary>
        public void MoveDown()
        {
            current.MoveDown();
        }

		/// <summary>
		/// Drops the <see cref="Shape"/> to the top of the pile.
		/// </summary>
        public void Drop()
        {
            current.Drop();
        }

		/// <summary>
		/// Rotates this <see cref="Shape"/> 90 degrees counterclockwise.
		/// </summary>
        public void Rotate()
        {
            current.Rotate();
        }

		/// <summary>
		/// Resets this instance.
		/// </summary>
        public void Reset()
        {
            current.Reset();
        }

        // TODO DeployNewShape() Not yet implemented
		/// <summary>
		/// Deploys a new shape.
		/// </summary>
        public void DeployNewShape()
        {
            int r = random.Next(7);

            throw new NotImplementedException();
        }

        #endregion
    }
}
