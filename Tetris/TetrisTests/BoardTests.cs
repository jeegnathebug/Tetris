using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TetrisLibrary;

namespace TetrisTests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void ValidConstructor()
        {
            //arrange
            IBoard board = new Board();

            //assert
            Assert.IsInstanceOfType(board,typeof(IBoard));
        }
        
        [TestMethod]
        public void MoveDown()
        {
            //arrange
            IBoard board = new Board();
            IShape shape = board.Shape;

            //act
            shape.MoveDown();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.WriteLine(board[i, j].ToString());
                }
            }
            //assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MoveLeft()
        {
            //arrange
            IBoard board = new Board();
            IShape shape = board.Shape;

            //act
            shape.MoveLeft();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.WriteLine(board[i, j].ToString());
                }
            }

            //assert
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void MoveRight()
        {
            //arrange
            IBoard board = new Board();
            IShape shape = board.Shape;

            //act
            shape.MoveRight();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.WriteLine(board[i, j].ToString());
                }
            }

            //assert
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void Rotate()
        {
            //arrange
            IBoard board = new Board();
            IShape shape = board.Shape;

            //act
            shape.Rotate();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.WriteLine(board[i, j].ToString());
                }
            }

            //assert
            Assert.IsTrue(true);
        }
    }
}
