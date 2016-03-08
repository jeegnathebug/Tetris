using System.Drawing;

namespace TetrisLibrary
{
    public class ShapeZ : Shape
    {
        private IBoard board;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeZ"/> class.
        /// </summary>
        /// <param name="board">The board being used.</param>
        public ShapeZ(IBoard board)
        {
            this.board = board;

            // Initialize blocks
            blocks = new Block[] {
                new Block (board, Color.Red),
                new Block (board, Color.Red),
                new Block (board, Color.Red),
                new Block (board, Color.Red)
            };

            // Set block positions
            setBlockPositions();

            // Set rotations
            rotationOffset = new Point[][]
            {
                new Point[] { new Point(-1, 0), new Point(0, -1) },
                new Point[] { new Point(0, 0), new Point(0, 0) },
                new Point[] { new Point(0, -1), new Point(1, 0) },
                new Point[] { new Point(1, -1), new Point(1, 1) }
            };

            // 0 = no rotation
            // 1 = 90 degree rotation counterclockwise
            currentRotation = 0;
        }

        /// <summary>
        /// Sets the blocks' positions.
        /// </summary>
        protected override void setBlockPositions()
        {
            this[0].Position = new Point(4, 0);
            this[1].Position = new Point(5, 0);
            this[2].Position = new Point(5, 1);
            this[3].Position = new Point(6, 1);
        }
    }
}
