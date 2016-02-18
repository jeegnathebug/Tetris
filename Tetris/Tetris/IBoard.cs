using System.Drawing;

namespace Tetris
{
    interface IBoard
    {
        // Properties
        IShape Shape{get;}

        // Indexers
        Color this[int i, int j]{get;}

        // Event handlers
        event LinesClearedHandler LinesCleared;
        event GameOverHandler GameOver;

        int GetLength(int rank);
    }
}
