using TetrisLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace TetrisTests
{
    [TestClass]
    public class ShapeSTest
    {
        [TestMethod]
        public void TestMethodShapeS_MoveLeft()
        {
            //arrange
            IBoard board = new Board();
            ShapeS shape = new ShapeS(board);

            //act
            shape.MoveLeft();

            //assert
            Assert.AreEqual(3, shape[0].Position.X);
            Assert.AreEqual(1, shape[0].Position.Y);
            Assert.AreEqual(4, shape[1].Position.X);
            Assert.AreEqual(1, shape[1].Position.Y);
            Assert.AreEqual(4, shape[2].Position.X);
            Assert.AreEqual(0, shape[2].Position.Y);
            Assert.AreEqual(5, shape[3].Position.X);
            Assert.AreEqual(0, shape[3].Position.Y);
        }

        [TestMethod]
        public void TestMethodShapeS_MoveRight()
        {
            //arrange
            IBoard board = new Board();
            ShapeS shape = new ShapeS(board);

            //act
            shape.MoveRight();

            //assert
            Assert.AreEqual(5, shape[0].Position.X);
            Assert.AreEqual(1, shape[0].Position.Y);
            Assert.AreEqual(6, shape[1].Position.X);
            Assert.AreEqual(1, shape[1].Position.Y);
            Assert.AreEqual(6, shape[2].Position.X);
            Assert.AreEqual(0, shape[2].Position.Y);
            Assert.AreEqual(7, shape[3].Position.X);
            Assert.AreEqual(0, shape[3].Position.Y);
        }

        [TestMethod]
        public void TestMethodShapeS_MoveDown()
        {
            //arrange
            IBoard board = new Board();
            ShapeS shape = new ShapeS(board);

            //act
            shape.MoveDown();

            //assert
            Assert.AreEqual(4, shape[0].Position.X);
            Assert.AreEqual(2, shape[0].Position.Y);
            Assert.AreEqual(5, shape[1].Position.X);
            Assert.AreEqual(2, shape[1].Position.Y);
            Assert.AreEqual(5, shape[2].Position.X);
            Assert.AreEqual(1, shape[2].Position.Y);
            Assert.AreEqual(6, shape[3].Position.X);
            Assert.AreEqual(1, shape[3].Position.Y);
        }

        [TestMethod]
        public void TestMethodShapeS_Rotate()
        {
            //arrange
            IBoard board = new Board();
            ShapeS shape = new ShapeS(board);

            //act
            shape.MoveDown();
            shape.Rotate();

            //assert
            Assert.AreEqual(6, shape[0].Position.X);
            Assert.AreEqual(2, shape[0].Position.Y);
            Assert.AreEqual(6, shape[1].Position.X);
            Assert.AreEqual(1, shape[1].Position.Y);
            Assert.AreEqual(5, shape[2].Position.X);
            Assert.AreEqual(1, shape[2].Position.Y);
            Assert.AreEqual(5, shape[3].Position.X);
            Assert.AreEqual(0, shape[3].Position.Y);
        }

        [TestMethod]
        public void TestMethodShapeS_Rotate2()
        {
            //arrange
            IBoard board = new Board();
            ShapeS shape = new ShapeS(board);

            //act
            shape.MoveDown();
            shape.Rotate();
            shape.Rotate();

            //assert
            Assert.AreEqual(4, shape[0].Position.X);
            Assert.AreEqual(2, shape[0].Position.Y);
            Assert.AreEqual(5, shape[1].Position.X);
            Assert.AreEqual(2, shape[1].Position.Y);
            Assert.AreEqual(5, shape[2].Position.X);
            Assert.AreEqual(1, shape[2].Position.Y);
            Assert.AreEqual(6, shape[3].Position.X);
            Assert.AreEqual(1, shape[3].Position.Y);
        }

        [TestMethod]
        public void TestMethodShapeS_Drop()
        {
            //arrange
            IBoard board = new Board();
            ShapeS shape = new ShapeS(board);

            //act
            shape.Drop();

            //assert
            Assert.AreEqual(4, shape[0].Position.X);
            Assert.AreEqual(19, shape[0].Position.Y);
            Assert.AreEqual(5, shape[1].Position.X);
            Assert.AreEqual(19, shape[1].Position.Y);
            Assert.AreEqual(5, shape[2].Position.X);
            Assert.AreEqual(18, shape[2].Position.Y);
            Assert.AreEqual(6, shape[3].Position.X);
            Assert.AreEqual(18, shape[3].Position.Y);
        }

        [TestMethod]
        public void TestMethodShapeS_Reset()
        {
            //arrange
            IBoard board = new Board();
            ShapeS shape = new ShapeS(board);

            shape.MoveDown();

            //act
            shape.Reset();

            //assert
            Assert.AreEqual(new Point(4, 1), shape[0].Position);
            Assert.AreEqual(new Point(5, 1), shape[1].Position);
            Assert.AreEqual(new Point(5, 0), shape[2].Position);
            Assert.AreEqual(new Point(6, 0), shape[3].Position);
       
        }
        [TestMethod]
        public void TestShapeS_DownRotateLeft()
        {
            //arrange
            IBoard board = new Board();
            ShapeS shape = new ShapeS(board);

            //act
            shape.MoveDown();
            shape.Rotate();
            shape.MoveLeft();


            //assert
            Assert.AreEqual(new Point(5, 2), shape[0].Position);
            Assert.AreEqual(new Point(5, 1), shape[1].Position);
            Assert.AreEqual(new Point(4, 1), shape[2].Position);
            Assert.AreEqual(new Point(4, 0), shape[3].Position);
        }
        [TestMethod]
        public void TestShapeS_DownRotateRight()
        {
            //arrange
            IBoard board = new Board();
            ShapeS shape = new ShapeS(board);

            //act
            shape.MoveDown();
            shape.Rotate();
            shape.MoveLeft();


            //assert
            Assert.AreEqual(new Point(5, 2), shape[0].Position);
            Assert.AreEqual(new Point(5, 1), shape[1].Position);
            Assert.AreEqual(new Point(4, 1), shape[2].Position);
            Assert.AreEqual(new Point(4, 0), shape[3].Position);
        }
        [TestMethod]
        public void TestShapeS_DownRotateDrop()
        {
            //arrange
            IBoard board = new Board();
            ShapeS shape = new ShapeS(board);
            // Act
            shape.MoveDown();
            shape.Rotate();
            shape.Drop();
            // Assert
            Assert.AreEqual(new Point(6, 19), shape[0].Position);
            Assert.AreEqual(new Point(6, 18), shape[1].Position);
            Assert.AreEqual(new Point(5, 18), shape[2].Position);
            Assert.AreEqual(new Point(5, 17), shape[3].Position);
        }

    }
}
