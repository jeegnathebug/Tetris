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
            board.LinesCleared += Board_LinesCleared;

            //assert
            Assert.AreEqual(1, score.Lines);
            Assert.AreEqual(1, score.Level);
            Assert.AreEqual(0, score.score);
        }

        private void Board_LinesCleared(int num)
        {
            Console.WriteLine("cleared "+ num);
        }
    }
}
