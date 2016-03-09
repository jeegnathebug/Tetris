using Microsoft.VisualStudio.TestTools.UnitTesting;
using TetrisLibrary;

namespace TetrisTests
{
    [TestClass]
    public class ShapeTests
    {
        [TestMethod]
        public void TestMethodShapeI()
        {
            //arrange
            IBoard board = new Board();
            ShapeI i = new ShapeI(board);

            //act

            //assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethodShapeJ()
        {
            ///arrange
            IBoard board = new Board();
            ShapeJ j = new ShapeJ(board);

            //act


            //assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethodShapeL()
        {
            //arrange
            IBoard board = new Board();
            ShapeL l = new ShapeL(board);

            //act


            //assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethodShapeO()
        {
            //arrange
            IBoard board = new Board();
            ShapeO o = new ShapeO(board);

            //act


            //assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethodShapeS()
        {
            //arrange
            IBoard board = new Board();
            ShapeS s = new ShapeS(board);

            //act


            //assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethodShapeT()
        {
            //arrange
            IBoard board = new Board();
            ShapeT t = new ShapeT(board);

            //act


            //assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethodShapeZ()
        {
            //arrange
            IBoard board = new Board();
            ShapeZ z = new ShapeZ(board);

            //act


            //assert
            Assert.IsTrue(true);
        }
    }
}
