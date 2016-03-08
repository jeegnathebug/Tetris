using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using TetrisLibrary;

namespace TetrisTests
{
    [TestClass]
    public class BlockTests
    {
        [TestMethod]
        public void TryMoveLeft()
        {
            //arrange
            Board board = new Board();
            Block block = new Block(board, Color.White);
            block.Position = new Point(2, 1);
            bool x;

            //act
            x = block.TryMoveLeft();

            //assert
            Assert.AreEqual(true, x);
        }

        [TestMethod]
        public void TryMoveRight()
        {
            //arrange
            Board board = new Board();
            Block block = new Block(board, Color.White);
            block.Position = new Point(1, 1);
            bool x;

            //act
            x = block.TryMoveRight();

            //assert
            Assert.AreEqual(true, x);
        }

        [TestMethod]
        public void TryMoveDown()
        {
            //arrange
            Board board = new Board();
            Block block = new Block(board, Color.White);
            block.Position = new Point(4, 4);
            bool x;

            //act
            x = block.TryMoveDown();

            //assert
            Assert.AreEqual(true, x);
        }

        [TestMethod]
        public void TryRotate()
        {
            //arrange
            Board board = new Board();
            Block block = new Block(board, Color.White);
            block.Position = new Point(8, 6);
            Point offset = new Point(1, 2); // Go to 9,8
            bool x;

            //act
            x = block.TryRotate(offset);

            //assert
            Assert.AreEqual(true, x);
        }

        [TestMethod]
        public void TryMoveLeftFalse()
        {
            //arrange
            Board board = new Board();
            Block block = new Block(board, Color.White);
           // block.Position = new Point(0, 1);
            bool x;

            //act
            x = block.TryMoveLeft();

            //assert
            Assert.AreEqual(false, x);
        }

        [TestMethod]
        public void TryMoveRightFalse()
        {
            //arrange
            Board board = new Board();
            Block block = new Block(board, Color.White);
            block.Position = new Point(9, 1);
            bool x;

            //act
            x = block.TryMoveRight();

            //assert
            Assert.AreEqual(false, x);
        }

        [TestMethod]
        public void TryMoveDownFalse()
        {
            //arrange
            Board board = new Board();
            Block block = new Block(board, Color.White);
            block.Position = new Point(4, 19);
            bool x;

            //act
            x = block.TryMoveDown();

            //assert
            Assert.AreEqual(false, x);
        }

        [TestMethod]
        public void TryRotateFalse()
        {
            //arrange
            Board board = new Board();
            Block block = new Block(board, Color.White);
            block.Position = new Point(8, 6);
            Point offset = new Point(2, 2); // Go to 10,8 -> does not exist
            bool x;

            //act
            x = block.TryRotate(offset);

            //assert
            Assert.AreEqual(false, x);
        }

        [TestMethod]
        public void MoveLeft()
        {
            //arrange
            Board board = new Board();
            Block block = new Block(board, Color.White);
            block.Position = new Point(2, 1);

            //act
            block.MoveLeft();

            //assert
            Assert.AreEqual(1, block.Position.X);
            Assert.AreEqual(1, block.Position.Y);
        }

        [TestMethod]
        public void MoveRight()
        {
            //arrange
            Board board = new Board();
            Block block = new Block(board, Color.White);
            block.Position = new Point(2, 1);

            //act
            block.MoveRight();

            //assert
            Assert.AreEqual(3, block.Position.X);
            Assert.AreEqual(1, block.Position.Y);
        }

        [TestMethod]
        public void MoveDown()
        {
            //arrange
            Board board = new Board();
            Block block = new Block(board, Color.White);
            block.Position = new Point(1, 6);

            //act
            block.MoveDown();

            //assert
            Assert.AreEqual(1, block.Position.X);
            Assert.AreEqual(6, block.Position.Y);
        }

        [TestMethod]
        public void Rotate()
        {
            //arrange
            Board board = new Board();
            Block block = new Block(board, Color.White);
            block.Position = new Point(8, 6);
            Point offset = new Point(1, 2);

            //act
            block.Rotate(offset);

            //assert
            Assert.AreEqual(9, block.Position.X);
            Assert.AreEqual(8, block.Position.Y);
        }
    }
}
