using System.Drawing;
using Microsoft.Xna.Framework;

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

        public Block(IBoard board, Color color)
        {
            this.board = board;
            this.color = color;
        }

        #endregion

        #region Methods

        // TODO all Try methods
        // If there are two blocks in a row (of the same shape),
        // when it tries to move any direction, it'll see the block next to it,
        // and say that it can't move, even though that block will move with it.
        // Use the board's colors for Try methods

        public bool TryMoveLeft()
        {
            bool canMove = false;

            return canMove;
        }

        public bool TryMoveRight()
        {
            bool canMove = false;

            return canMove;
        }

        public bool TryMoveDown()
        {
            bool canMove = false;

            return canMove;
        }

        public bool TryRotate(Point offset)
        {
            bool canRotate = false;

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