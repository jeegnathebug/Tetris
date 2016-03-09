using TetrisLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TetrisTests
{
    [TestClass]
    public class ShapeJTest
    {

        [TestMethod]
        public void TestMethodShapeJ_Rotate()
        {
            //arrange
            IBoard board = new Board();
            ShapeJ shape = new ShapeJ(board);

            shape.MoveDown();

            //act
            shape.Rotate();

            //assert
            Assert.AreEqual(5, shape[0].Position.X);
            Assert.AreEqual(3, shape[0].Position.Y);
            Assert.AreEqual(5, shape[1].Position.X);
            Assert.AreEqual(2, shape[1].Position.Y);
            Assert.AreEqual(5, shape[2].Position.X);
            Assert.AreEqual(1, shape[2].Position.Y);
            Assert.AreEqual(5, shape[3].Position.X);
            Assert.AreEqual(0, shape[3].Position.Y);
        }
    }
}
