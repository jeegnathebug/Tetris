using System.Drawing;

namespace TetrisLibrary
{
    public class Block
    {
        #region Fields

        private IBoard board;
        private int x;
        private int y;

        private Color color;
        private Point position;

        #endregion

        #region Properties

        public Color Color
        {
            get { return color; }
        }

        public Point Position
        {
            get { return position; }
            set { position = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Block"/> class.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="color">The color of the block.</param>
        public Block(IBoard board, Color color)
        {
            this.board = board;
            x = board.GetLength(0) - 1;
            y = board.GetLength(1) - 1;

            this.color = color;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Tries to move the <see cref="Block"/> left.
        /// </summary>
        /// <returns><c>true</c>, if the <see cref="Block"/> can move left, <c>false</c> otherwise.</returns>
        public bool TryMoveLeft()
        {
            bool canMove = false;

            if (position.X == 0)
            {
                return false;
            }

            if (board[position.X - 1, position.Y].Equals(Color.Black))
            {
                canMove = true;
            }

            return canMove;
        }

        /// <summary>
        /// Tries to move the <see cref="Block"/> right.
        /// </summary>
        /// <returns><c>true</c>, if the <see cref="Block"/> can move right, <c>false</c> otherwise.</returns>
        public bool TryMoveRight()
        {
            bool canMove = false;

            if (position.X == x)
            {
                return false;
            }

            if (board[position.X + 1, position.Y].Equals(Color.Black))
            {
                canMove = true;
            }

            return canMove;
        }

        /// <summary>
        /// Tries to move the <see cref="Block"/> down.
        /// </summary>
        /// <returns><c>true</c>, if the <see cref="Block"/> can move down, <c>false</c> otherwise.</returns>
        public bool TryMoveDown()
        {
            bool canMove = false;

            if (position.Y == y)
            {
                return false;
            }

            if (board[position.X, position.Y + 1].Equals(Color.Black))
            {
                canMove = true;
            }

            return canMove;
        }

        /// <summary>
        /// Tries to rotate the <see cref="Block"./>
        /// </summary>
        /// <returns><c>true</c>, if the <see cref="Block"/> can be rotated, <c>false</c> otherwise.</returns>
        /// <param name="offset">The offset to rotate the <see cref="Block"/>.</param>
        public bool TryRotate(Point offset)
        {
            bool canRotate = false;

            int newX = position.X + offset.X;
            int newY = position.Y + offset.Y;

            // Check board boundaries
            if ((newX < 0 || newX > x) || (newY < 0 || newY > y))
            {
                return false;
            }

            if (board[newX, newY].Equals(Color.Black))
            {
                canRotate = true;
            }

            return canRotate;
        }

		/// <summary>
		/// Moves the <see cref="Block"/> left if it can be moved.
		/// </summary>
        public void MoveLeft()
        {
            if (TryMoveLeft())
            {
                position.Offset(-1, 0);
            }
        }

		/// <summary>
		/// Moves the <see cref="Block"/> right if it can be moved.
		/// </summary>
        public void MoveRight()
        {
            if (TryMoveRight())
            {
                position.Offset(1, 0);
            }
        }

		/// <summary>
		/// Moves the <see cref="Block"/> down if it can be moved.
		/// </summary>
        public void MoveDown()
        {
            if (TryMoveDown())
            {
                position.Offset(0, 1);
            }
        }

		/// <summary>
		/// Rotates the <see cref="Block"/> by the given offset if it can be rotated.
		/// </summary>
		/// <param name="offset">The offset to rotate the <see cref="Block"/>.</param>
        public void Rotate(Point offset)
        {
            if (TryRotate(offset))
            {
                position.Offset(offset.X, offset.Y);
            }
        }
        #endregion
    }
}
