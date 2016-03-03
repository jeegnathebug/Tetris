using System.Drawing;

namespace TetrisLibrary
{
    public class Block
    {
        #region Fields

        private IBoard board;
        private Color color;

        #endregion

        #region Properties

        public Color Color
        {
            get { return color; }
        }

        public Point Position
        {
            get { return Position; }
            set { Position = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Block"/> class.
        /// </summary>
        /// <param name="board">The board</param>
        /// <param name="color">The color of the block</param>
        public Block(IBoard board, Color color)
        {
            this.board = board;
            this.color = color;
        }

        #endregion

        #region Methods

        public bool TryMoveLeft()
        {
            bool canMove = false;

            if (board[Position.X - 1, Position.Y].IsEmpty)
            {
                canMove = true;
            }

            return canMove;
        }

        public bool TryMoveRight()
        {
            bool canMove = false;

            if (board[Position.X + 1, Position.Y].IsEmpty)
            {
                canMove = true;
            }

            return canMove;
        }

        public bool TryMoveDown()
        {
            bool canMove = false;

            if (board[Position.X, Position.Y + 1].IsEmpty)
            {
                canMove = true;
            }

            return canMove;
        }

        public bool TryRotate(Point offset)
        {
            bool canRotate = false;

            if (board[Position.X + offset.X, Position.Y + offset.Y].IsEmpty)
            {
                canRotate = true;
            }

            return canRotate;
        }

        public void MoveLeft()
        {
            if (TryMoveLeft())
            {
                Position.Offset(-1, 0);
            }
        }

        public void MoveRight()
        {
            if (TryMoveRight())
            {
                Position.Offset(1, 0);
            }
        }

        public void MoveDown()
        {
            if (TryMoveDown())
            {
                Position.Offset(0, 1);
            }
        }

        public void Rotate(Point offset)
        {
            if (TryRotate(offset))
            {
                Position.Offset(offset.X, offset.Y);
            }
        }

        #endregion
    }
}