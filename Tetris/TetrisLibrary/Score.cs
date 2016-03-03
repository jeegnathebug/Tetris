using System;
using Microsoft.Xna.Framework;

namespace TetrisLibrary
{
    class Score
    {
        #region Fields

        private int level;
        private int lines;
        private int _score;

        private IBoard board;

        #endregion

        #region Constructor

        public Score(IBoard board)
        {
            this.board = board;

            level = 0;
            lines = 0;
            _score = 0;

            // Event handler
            board.LinesCleared += new LinesClearedHandler(incrementLinesCleared);
        }

        #endregion

        #region Properties

        public int Level
        {
            get { return level; }
        }

        public int Lines
        {
            get { return lines; }
        }

        public int score
        {
            get { return _score; }
        }

        #endregion

        #region Event Handlers/Methods

        private void incrementLinesCleared(int num)
        {
            if (num >= 0)
            {
                lines += num;
            }
        }

        #endregion
    }
}
