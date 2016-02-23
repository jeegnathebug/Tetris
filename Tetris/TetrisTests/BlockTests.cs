using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace TetrisTests
{
    [TestClass]
    public class BlockTests
    {
        [TestMethod]
        private void TryMoveLeft()
        {
            //arrange
            TetrisLibrary.Block block = new TetrisLibrary.Block();
            block.Position = new Point(2, 1);
            bool x;

            //act
            x = block.TryMoveLeft();

            //assert
            Assert.AreEqual(true, x);
        }
        [TestMethod]
        private void TryMoveRight()
        {
            //arrange
            TetrisLibrary.Block block = new TetrisLibrary.Block();
            block.Position = new Point(1, 1);
            bool x;

            //act
            x = block.TryMoveRight();

            //assert
            Assert.AreEqual(true, x);
        }
        [TestMethod]
        private void TryMoveDown()
        {
            //arrange
            TetrisLibrary.Block block = new TetrisLibrary.Block();
            block.Position = new Point(4, 4);
            bool x;

            //act
            x = block.TryMoveDown();

            //assert
            Assert.AreEqual(true, x);
        }
        [TestMethod]
        private void TryRotate()
        {
            //arrange
            TetrisLibrary.Block block = new TetrisLibrary.Block();
            block.Position = new Point(8, 6);
            Point offset = new Point(1,2);
            bool x;

            //act
            x = block.TryRotate(offset);

            //assert
            Assert.AreEqual(true, x);
        }
        [TestMethod]
        private void MoveLeft()
        {
            //arrange
            TetrisLibrary.Block block = new TetrisLibrary.Block();
            block.Position = new Point(2, 1);

            //act
            block.MoveLeft();

            //assert
            Assert.AreEqual(1, block.Position.X);
            Assert.AreEqual(1, block.Position.Y);
        }
        [TestMethod]
        private void MoveRight()
        {
            //arrange
            TetrisLibrary.Block block = new TetrisLibrary.Block();
            block.Position = new Point(2, 1);

            //act
            block.MoveRight();

            //assert
            Assert.AreEqual(3, block.Position.X);
            Assert.AreEqual(1, block.Position.Y);
        }
        [TestMethod]
        private void MoveDown()
        {
            //arrange
            TetrisLibrary.Block block = new TetrisLibrary.Block();
            block.Position = new Point(1, 6);

            //act
            block.MoveDown();

            //assert
            Assert.AreEqual(1, block.Position.X);
            Assert.AreEqual(6, block.Position.Y);
        }
        [TestMethod]
        private void Rotate()
        {
            //arrange
            TetrisLibrary.Block block = new TetrisLibrary.Block();
            block.Position = new Point(8, 6);
            Point offset = new Point(1, 2);

            //act
            block.Rotate(offset);

            //assert
            Assert.AreEqual(8, block.Position.X);
            Assert.AreEqual(6, block.Position.Y);
        }
    }
}
