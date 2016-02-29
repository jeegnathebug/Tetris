using System.Drawing;
using Microsoft.Xna.Framework;

namespace TetrisLibrary
{
    class ShapeO : Shape
    {
        private IBoard board;

        /// <summary>
        /// Initializes a new instance of the <see cref="TetrisLibrary.ShapeO"/> class.
        /// </summary>
        /// <param name="board">The board being used.</param>
        public ShapeO(IBoard board)
        {
            this.board = board;

            // Initialize blocks
            blocks = new Block[] {
                new Block (board, Color.Yellow),
                new Block (board, Color.Yellow),
                new Block (board, Color.Yellow),
                new Block (board, Color.Yellow)
            };

            // Set block positions
            blocks[0].Position = new Point(-1, 0);
            blocks[1].Position = new Point(-1, -1);
            blocks[2].Position = new Point(0, 0);
            blocks[3].Position = new Point(0, -1);
        }

        /// <summary>
        /// Moves the shape left.
        /// </summary>
        public override void MoveLeft()
        {
            bool canMove = false;

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
        /// Moves the shape right.
        /// </summary>
        public override void MoveRight()
        {
            bool canMove = false;

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
        /// Moves the shape down.
        /// </summary>
        public override void MoveDown()
        {
            bool canMove = false;

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
            }
        }

        /// <summary>
        /// Rotates this shape 90 degrees counterclockwise.
        /// </summary>
        public override void Rotate()
        {
            return;
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public override void Reset()
        {
        }
    }
}
