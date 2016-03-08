using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TetrisLibrary;

namespace TetrisTests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void TestMethod1()
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
    }
}
