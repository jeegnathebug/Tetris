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
            ShapeProxy proxy = new ShapeProxy(board);

            //act

            //assert
        }
    }
}
