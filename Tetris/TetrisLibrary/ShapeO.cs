using System.Drawing;

namespace TetrisLibrary
{
    class ShapeO : Shape
    {
        private IBoard board;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeO"/> class.
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
            setBlockPositions();

            // -1 = do not rotate
            currentRotation = -1;
        }

        protected override void setBlockPositions()
        {
            blocks[0].Position = new Point(-1, 0);
            blocks[1].Position = new Point(-1, -1);
            blocks[2].Position = new Point(0, 0);
            blocks[3].Position = new Point(0, -1);
        }
    }
}
