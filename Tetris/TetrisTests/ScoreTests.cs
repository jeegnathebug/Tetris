using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TetrisLibrary;

namespace TetrisTests
{
    [TestClass]
    public class ScoreTests
    {
        [TestMethod]
        public void Score()
        {
            //arrange
            Board board = new Board();
            Score score = new Score(board);

            //act


            //assert
            Assert.IsTrue(true);
        }
    }
}
