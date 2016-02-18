namespace Tetris
{
    interface IShape
    {
        // Properties
        int Length{get;}

        // Indexers
        Block this[int i]{get;}

        // Event handlers
        event JoinPileHandler JoinPile;

        //Methods
        void MoveLeft();

        void MoveRight();

        void MoveDown();

        void Drop();

        void Rotate();

        void Reset();
    }
}
