using System;
using Microsoft.Xna.Framework;

namespace TetrisLibrary
{
    class Score
    {
        #region Properties
        public int Level
        {
            get { return Level; }
        }

        public int Lines
        {
            get { return Lines; }
        }

        public int score
        {
            get { return score; }
        }
        #endregion

        #region Event Handlers/Methods
        private void incrementLinesCleared(int num)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
