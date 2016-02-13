using System;
using System.Drawing;

namespace Tetris
{
    public class Block
    {
        private IBoard board;
        private Color color;

        // Properties
        public Color Color
        {
            get { return color; }
        }

        public Point Position
        {
            get { return Position; }
            set { Position = value; }
        }

        public bool TryMoveLeft()
        {
            throw new NotImplementedException();
        }

        public bool TryMoveRight()
        {
            throw new NotImplementedException();
        }

        public bool TryMoveDown()
        {
            throw new NotImplementedException();
        }

        public bool TryRotate(Point offset)
        {
            throw new NotImplementedException();
        }

        public void MoveLeft()
        {
            throw new NotImplementedException();
        }

        public void MoveRight()
        {
            throw new NotImplementedException();
        }

        public void MoveDown()
        {
            throw new NotImplementedException();
        }


        public void Rotate(Point offset)
        {
            throw new NotImplementedException();
        }
    }
}