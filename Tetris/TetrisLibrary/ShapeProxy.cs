using System;

namespace TetrisLibrary
{
    public class ShapeProxy : IShape, IShapeFactory
    {
        #region Fields

        private static Random random;

        private IBoard board;
        // The shape I'm pretending to be
        private IShape current;

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
        /// Initializes a new instance of the <see cref="ShapeProxy"/> class. This class is a stand-in for an instance of the <see cref="IShape"/> interface
        /// </summary>
        /// <param name="board">The board.</param>
        public ShapeProxy(IBoard board)
        {
            random = new Random();
            this.board = board;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Raises the join pile event.
        /// </summary>
        /// <param name="shape">The shape to be used as the parameter for the event</param>
        protected void OnJoinPile(IShape shape)
        {
            if (JoinPile != null)
            {
                JoinPile(shape);
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

         /// <summary>
        /// Deploys a randomly chosen new shape
        /// </summary>
        public void DeployNewShape()
        {
			DeployShape(random.Next(7));
        }

		/// <summary>
		/// Deploys a <see cref="Shape"/> based on the given number.
		/// </summary>
		/// <param name="num">The number of the <see cref="Shape"/>, where 0 = ShapeI, 1 = Shape J, 2 = ShapeL, 3 = ShapeO, 4 = ShapeS, 5 = ShapeT, and 6 = ShapeZ</param>
		public void DeployShape(int num) {
			switch (num)
			{
			case 0:
				current = new ShapeI(board);
				break;
			case 1:
				current = new ShapeJ(board);
				break;
			case 2:
				current = new ShapeL(board);
				break;
			case 3:
				current = new ShapeO(board);
				break;
			case 4:
				current = new ShapeS(board);
				break;
			case 5:
				current = new ShapeT(board);
				break;
			case 6:
				current = new ShapeZ(board);
				break;
			default:
				current = null;
				break;
			}

			// Event handler
			current.JoinPile += new JoinPileHandler(OnJoinPile);
		}

        #endregion
    }
}
