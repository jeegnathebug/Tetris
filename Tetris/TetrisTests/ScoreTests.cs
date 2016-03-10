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

            ScoreTests matan = new ScoreTests();
            //act -> maybe just see if event flag is raised
            board.LinesCleared += new LinesClearedHandler(Board_LinesCleared);
            Board_LinesCleared(2);
            
            //assert
            Assert.AreEqual(0, score.Lines);
            Assert.AreEqual(1, score.Level);
            Assert.AreEqual(0, score.score);
        }
        [TestMethod]
        public void GameOverTest()
        {
            //arrange
            Board board = new Board();
            Score score = new Score(board);
            bool eventCaught = false;

            //act
            board.GameOver += () => eventCaught = true;
            //assert
            Assert.IsTrue(eventCaught);
        }

        private void Board_LinesCleared(int num)
        {
            Console.WriteLine("cleared "+ num);
        }
    }
}
