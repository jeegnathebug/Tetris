using System.Drawing;

namespace TetrisLibrary
{
    public class ShapeS : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeS"/> class.
        /// </summary>
        /// <param name="board">The board being used.</param>
        public ShapeS(IBoard board) : base(board)
        {
            // Initialize blocks
            blocks = new Block[] {
                new Block (board, Color.Lime),
                new Block (board, Color.Lime),
                new Block (board, Color.Lime),
                new Block (board, Color.Lime)
            };

            // Set block positions
            setBlockPositions();

            // Set rotations
            rotationOffset = new Point[][]
            {
                new Point[] { new Point(-2, 0), new Point(2, 0) },
                new Point[] { new Point(-1, 1), new Point(1, -1) },
                new Point[] { new Point(0, 0), new Point(0, 0) },
                new Point[] { new Point(1, 1), new Point(-1, -1) }
            };

            // 0 = no rotation
            // 1 = 90 degree rotation counterclockwise
            currentRotation = 0;

            length = blocks.Length;
        }

		/// <summary>
		/// Sets the blocks' positions.
		/// </summary>
        protected override void setBlockPositions()
        {
            blocks[0].Position = new Point(4, 1);
            blocks[1].Position = new Point(5, 1);
            blocks[2].Position = new Point(5, 0);
            blocks[3].Position = new Point(6, 0);
        }
    }
}
