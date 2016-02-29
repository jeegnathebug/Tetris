using System.Drawing;
using Microsoft.Xna.Framework;


namespace TetrisLibrary
{
    public delegate void LinesClearedHandler(int num);
    public delegate void GameOverHandler();

    public interface IBoard
    {
        // Properties
        IShape Shape { get; }

        // Indexers
        Color this[int i, int j] { get; }

        // Event handlers
        event LinesClearedHandler LinesCleared;
        event GameOverHandler GameOver;

        int GetLength(int rank);
    }
}
