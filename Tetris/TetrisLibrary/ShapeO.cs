using System.Drawing;

namespace TetrisLibrary
{
    public class ShapeO : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeO"/> class.
        /// </summary>
        /// <param name="board">The board being used.</param>
        public ShapeO(IBoard board) : base(board)
        {
            // Initialize blocks
            blocks = new Block[] {
                new Block (board, Color.Yellow),
                new Block (board, Color.Yellow),
                new Block (board, Color.Yellow),
                new Block (board, Color.Yellow)
            };

            // Set block positions
            setBlockPositions();

            // -1 = do not rotate
            currentRotation = -1;

            length = blocks.Length;
        }

		/// <summary>
		/// Sets the blocks' positions.
		/// </summary>
        protected override void setBlockPositions()
        {
            blocks[0].Position = new Point(4, 0);
            blocks[1].Position = new Point(4, 1);
            blocks[2].Position = new Point(5, 0);
            blocks[3].Position = new Point(6, 1);
        }
    }
}
