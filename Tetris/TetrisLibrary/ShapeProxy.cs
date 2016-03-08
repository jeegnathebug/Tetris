using System;

namespace TetrisLibrary
{
    public class ShapeProxy : IShape, IShapeFactory
    {
        #region Fields

        private static Random random;
        private IShape current; // The shape I'm pretending to be
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
        /// Deploys a new shape
        /// </summary>
        public void DeployNewShape()
        {
            int r = random.Next(7);

            //switch (r)
            //{
            //    case 0:
            //        current = new ShapeI(board);
            //        break;
            //    case 1:
            //        current = new ShapeJ(board);
            //        break;
            //    case 2:
            //        current = new ShapeL(board);
            //        break;
            //    case 3:
            //        current = new ShapeO(board);
            //        break;
            //    case 4:
            //        current = new ShapeS(board);
            //        break;
            //    case 5:
            //        current = new ShapeT(board);
            //        break;
            //    case 6:
            //        current = new ShapeZ(board);
            //        break;
            //    default:
            //        current = null;
            //        break;
            //}

            current = new ShapeZ(board);

            // Event handler
            current.JoinPile += new JoinPileHandler(OnJoinPile);
        }

        #endregion
    }
}
