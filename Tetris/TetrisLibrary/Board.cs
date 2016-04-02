using System.Drawing;

namespace TetrisLibrary
{
    public class Board : IBoard
    {
        #region Fields

        private Color[,] board;
        private IShape shape;
        private IShapeFactory shapeFactory;

        public event LinesClearedHandler LinesCleared;
        public event GameOverHandler GameOver;

        #endregion

        #region Properties

        public IShape Shape
        {
            get { return shape; }
        }

        public Color this[int i, int j]
        {
            get { return board[i, j]; }
            // HACK: FOR TESTING
            set { board[i, j] = value; }
        }

        // HACK: FOR TESTING
        public IShapeFactory ShapeFactory
        {
            get { return shapeFactory; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class.
        /// </summary>
        /// <param name="shapeFactory">The <see cref="ShapeFactory"/>.</param>
        public Board()
        {
            board = new Color[10, 20];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    board[i, j] = Color.Black;
                }
            }

            ShapeProxy proxy = new ShapeProxy(this);
            shapeFactory = proxy;
            shape = proxy;

            // Event handler
            shape.JoinPile += new JoinPileHandler(addToPile);

            shapeFactory.DeployNewShape();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the length of the given rank
        /// </summary>
        /// <returns>The length of the rank.</returns>
        /// <param name="rank">The rank whose Length is to be determined.</param>
        public int GetLength(int rank)
        {
            return board.GetLength(rank);
        }

        /// <summary>
        /// Raises the lines cleared event.
        /// </summary>
        /// <param name="lines">Number of lines cleared.</param>
        protected void OnLinesCleared(int lines)
        {
            if (LinesCleared != null)
            {
                LinesCleared(lines);
            }
        }

        /// <summary>
        /// Raises the game over event.
        /// </summary>
        protected void OnGameOver()
        {
            if (GameOver != null)
            {
                GameOver();
            }
        }

        /// <summary>
        /// Adds the <see cref="Shape"/> to the pile.
        /// </summary>
        /// <param name="shape">The shape to be added to the pile.</param>
        private void addToPile(IShape shape)
        {
            for (int i = 0; i < shape.Length; i++)
            {
                board[shape[i].Position.X, shape[i].Position.Y] = shape[i].Color;
            }

            // Clear any line that has been completed
            clearLines();

            // Create new shape for ShapeProxy
            shapeFactory.DeployNewShape();

            // Check game over
            gameOver();
        }

        private void clearLines()
        {
            int num = 0;

            // Go through each row from bottom up
            for (int j = board.GetLength(1) - 1; j >= 0; j--)
            {
                bool trueClear = true;
                bool drop = true;

                // Check each block from left to right
                for (int i = 0; i < GetLength(0); i++)
                {
                    trueClear &= !board[i, j].Equals(Color.Black);
                    drop &= board[i, j].Equals(Color.DarkSlateGray);
                }

                // If the line needs to be cleared
                if (trueClear)
                {
                    // bottommost line to be dropped
                    dropLines(j);

                    if (!drop)
                    {
                        // Increment lines cleared
                        num++;

                        // recheck the line
                        j++;
                    }
                }
            }

            // If any lines were cleared, fire event
            if (num != 0)
            {
                OnLinesCleared(num);
            }
        }

        /// <summary>
        /// Drops the given line until it joins the pile
        /// </summary>
        /// <param name="j">The line to drop</param>
        private void dropLines(int j)
        {
            // Not the very top line
            if (j != 0)
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    // Drop every row above
                    for (int k = j; k > 0; k--)
                    {
                        board[i, k] = board[i, k - 1];
                        board[i, k - 1] = Color.Black;
                    }
                }
            }
            // The very top line
            else
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    board[i, j] = Color.Black;
                }
            }
        }

        private void gameOver()
        {
            bool canPlace = true;

            // Check if new shape can be placed at start location
            for (int i = 0; i < shape.Length; i++)
            {
                Point p = shape[i].Position;
                canPlace &= board[p.X, p.Y].Equals(Color.Black);
            }

            // If block cannot be placed, end game
            if (!canPlace)
            {
                OnGameOver();
            }
        }

        #endregion
    }
}
