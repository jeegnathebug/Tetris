using Microsoft.Xna.Framework;

namespace TetrisLibrary
{
    public delegate void JoinPileHandler(IShape shape);

    public interface IShape
    {
        // Properties
        int Length { get; }

        // Indexers
        Block this[int i] { get; }

        // Event handlers
        event JoinPileHandler JoinPile;

        //Methods
        /// <summary>
        /// Moves the shape left.
        /// </summary>
        void MoveLeft();

        /// <summary>
        /// Moves the shape right.
        /// </summary>
        void MoveRight();

        /// <summary>
        /// Moves the shape down.
        /// </summary>
        void MoveDown();

        /// <summary>
        /// Drop this shape to the top of the pile.
        /// </summary>
        void Drop();

        /// <summary>
        /// Rotates this shape 90 degrees counterclockwise.
        /// </summary>
        void Rotate();

        /// <summary>
        /// Resets this instance.
        /// </summary>
        void Reset();
    }
}
