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

		/// <summary>
		/// Gets the length of the given rank
		/// </summary>
		/// <returns>The length of the rank.</returns>
		/// <param name="rank">The rank whose Length is to be determined.</param>
        int GetLength(int rank);
    }
}
