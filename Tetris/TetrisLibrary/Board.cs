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

            // TODO pretty sure this is wrong
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
        }

        private void clearLines()
        {
            int num = 0;

            // Check lines
            bool cleared = true;
            for (int i = 0; i < board.GetLength(1); i++)
            {
                for (int j = 0; j < GetLength(j); j++)
                {
                    cleared &= !board[i, j].IsEmpty;
                }

                if (cleared)
                {
                    num++;
                }

                cleared = true;
            }

            // If any lines were cleared, fire event
            if (num != 0)
            {
                OnLinesCleared(num);
            }
        }

        #endregion
    }
}
