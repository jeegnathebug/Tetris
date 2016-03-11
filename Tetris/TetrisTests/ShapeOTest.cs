using TetrisLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace TetrisTests
{
    [TestClass]
    public class ShapeOTest
    {
        [TestMethod]
        public void TestMethodShapeO_MoveLeft()
        {
            //arrange
            IBoard board = new Board();
            ShapeO shape = new ShapeO(board);

            //act
            shape.MoveLeft();

            //assert
            Assert.AreEqual(3, shape[0].Position.X);
            Assert.AreEqual(0, shape[0].Position.Y);
            Assert.AreEqual(3, shape[1].Position.X);
            Assert.AreEqual(1, shape[1].Position.Y);
            Assert.AreEqual(4, shape[2].Position.X);
            Assert.AreEqual(0, shape[2].Position.Y);
            Assert.AreEqual(4, shape[3].Position.X);
            Assert.AreEqual(1, shape[3].Position.Y);
        }

        [TestMethod]
        public void TestMethodShapeO_MoveRight()
        {
            //arrange
            IBoard board = new Board();
            ShapeO shape = new ShapeO(board);

            //act
            shape.MoveRight();

            //assert
            Assert.AreEqual(5, shape[0].Position.X);
            Assert.AreEqual(0, shape[0].Position.Y);
            Assert.AreEqual(5, shape[1].Position.X);
            Assert.AreEqual(1, shape[1].Position.Y);
            Assert.AreEqual(6, shape[2].Position.X);
            Assert.AreEqual(0, shape[2].Position.Y);
            Assert.AreEqual(6, shape[3].Position.X);
            Assert.AreEqual(1, shape[3].Position.Y);
        }

        [TestMethod]
        public void TestMethodShapeO_MoveDown()
        {
            //arrange
            IBoard board = new Board();
            ShapeO shape = new ShapeO(board);

            //act
            shape.MoveDown();

            //assert
            Assert.AreEqual(4, shape[0].Position.X);
            Assert.AreEqual(1, shape[0].Position.Y);
            Assert.AreEqual(4, shape[1].Position.X);
            Assert.AreEqual(2, shape[1].Position.Y);
            Assert.AreEqual(5, shape[2].Position.X);
            Assert.AreEqual(1, shape[2].Position.Y);
            Assert.AreEqual(5, shape[3].Position.X);
            Assert.AreEqual(2, shape[3].Position.Y);
        }

        [TestMethod]
        public void TestMethodShapeO_Rotate()
        {
            //arrange
            IBoard board = new Board();
            ShapeO shape = new ShapeO(board);

            //act
            shape.Rotate();

            //assert
            Assert.AreEqual(4, shape[0].Position.X);
            Assert.AreEqual(0, shape[0].Position.Y);
            Assert.AreEqual(4, shape[1].Position.X);
            Assert.AreEqual(1, shape[1].Position.Y);
            Assert.AreEqual(5, shape[2].Position.X);
            Assert.AreEqual(0, shape[2].Position.Y);
            Assert.AreEqual(5, shape[3].Position.X);
            Assert.AreEqual(1, shape[3].Position.Y);
        }

        [TestMethod]
        public void TestMethodShapeO_Rotate2()
        {
            //arrange
            IBoard board = new Board();
            ShapeO shape = new ShapeO(board);

            shape.Rotate();

            //act
            shape.Rotate();

            //assert
            Assert.AreEqual(4, shape[0].Position.X);
            Assert.AreEqual(0, shape[0].Position.Y);
            Assert.AreEqual(4, shape[1].Position.X);
            Assert.AreEqual(1, shape[1].Position.Y);
            Assert.AreEqual(5, shape[2].Position.X);
            Assert.AreEqual(0, shape[2].Position.Y);
            Assert.AreEqual(5, shape[3].Position.X);
            Assert.AreEqual(1, shape[3].Position.Y);
        }

        [TestMethod]
        public void TestMethodShapeO_Drop()
        {
            //arrange
            IBoard board = new Board();
            ShapeO shape = new ShapeO(board);

            //act
            shape.Drop();

            //assert
            Assert.AreEqual(4, shape[0].Position.X);
            Assert.AreEqual(18, shape[0].Position.Y);
            Assert.AreEqual(4, shape[1].Position.X);
            Assert.AreEqual(19, shape[1].Position.Y);
            Assert.AreEqual(5, shape[2].Position.X);
            Assert.AreEqual(18, shape[2].Position.Y);
            Assert.AreEqual(5, shape[3].Position.X);
            Assert.AreEqual(19, shape[3].Position.Y);
        }

        [TestMethod]
        public void TestMethodShapeO_Reset()
        {
            //arrange
            IBoard board = new Board();
            ShapeO shape = new ShapeO(board);

            shape.MoveDown();

            //act
            shape.Reset();

            //assert
            Assert.AreEqual(4, shape[0].Position.X);
            Assert.AreEqual(0, shape[0].Position.Y);
            Assert.AreEqual(4, shape[1].Position.X);
            Assert.AreEqual(1, shape[1].Position.Y);
            Assert.AreEqual(5, shape[2].Position.X);
            Assert.AreEqual(0, shape[2].Position.Y);
            Assert.AreEqual(5, shape[3].Position.X);
            Assert.AreEqual(1, shape[3].Position.Y);
        }
        [TestMethod]
        public void TestShapeO_DownRotateLeft()
        {
            //arrange
            IBoard board = new Board();
            ShapeO shape = new ShapeO(board);

            //act
            shape.MoveDown();
            shape.Rotate();
            shape.MoveLeft();


            //assert
            Assert.AreEqual(new Point(3, 1), shape[0].Position);
            Assert.AreEqual(new Point(3, 2), shape[1].Position);
            Assert.AreEqual(new Point(4, 1), shape[2].Position);
            Assert.AreEqual(new Point(4, 2), shape[3].Position);
        }
        [TestMethod]
        public void TestShapeO_DownRotateRight()
        {
            //arrange
            IBoard board = new Board();
            ShapeO shape = new ShapeO(board);

            //act
            shape.MoveDown();
            shape.Rotate();
            shape.MoveLeft();


            //assert
            Assert.AreEqual(new Point(3, 1), shape[0].Position);
            Assert.AreEqual(new Point(3, 2), shape[1].Position);
            Assert.AreEqual(new Point(4, 1), shape[2].Position);
            Assert.AreEqual(new Point(4, 2), shape[3].Position);
        }
        [TestMethod]
        public void TestShapeO_DownRotateDrop()
        {
            //arrange
            IBoard board = new Board();
            ShapeO shape = new ShapeO(board);

            //act
            shape.MoveDown();
            shape.Rotate();
            shape.Drop();

            //assert
            Assert.AreEqual(new Point(4, 18), shape[0].Position);
            Assert.AreEqual(new Point(4, 19), shape[1].Position);
            Assert.AreEqual(new Point(5, 18), shape[2].Position);
            Assert.AreEqual(new Point(5, 19), shape[3].Position);
        }
        [TestMethod]
        public void TestShapeO_AllLeft()
        {
            //arrange
            IBoard board = new Board();
            ShapeO shape = new ShapeO(board);

            //act
            shape.MoveLeft();
            shape.MoveLeft();
            shape.MoveLeft();
            shape.MoveLeft();
            shape.MoveLeft();

            //assert
            Assert.AreEqual(new Point(0, 0), shape[0].Position);
            Assert.AreEqual(new Point(0, 1), shape[1].Position);
            Assert.AreEqual(new Point(1, 0), shape[2].Position);
            Assert.AreEqual(new Point(1, 1), shape[3].Position);
        }
        [TestMethod]
        public void TestShapeO_AllRight()
        {
            //arrange
            IBoard board = new Board();
            ShapeO shape = new ShapeO(board);

            //act
            shape.MoveRight();
            shape.MoveRight();
            shape.MoveRight();
            shape.MoveRight();
            shape.MoveRight();

            //assert
            Assert.AreEqual(new Point(8, 0), shape[0].Position);
            Assert.AreEqual(new Point(8, 1), shape[1].Position);
            Assert.AreEqual(new Point(9, 0), shape[2].Position);
            Assert.AreEqual(new Point(9, 1), shape[3].Position);
        }
        [TestMethod]
        public void TestShapeO_InvalidRotate()
        {
            //arrange
            IBoard board = new Board();
            ShapeO shape = new ShapeO(board);

            //act
            shape.Rotate();

            // Assert
            Assert.AreEqual(new Point(4, 0), shape[0].Position);
            Assert.AreEqual(new Point(4, 1), shape[1].Position);
            Assert.AreEqual(new Point(5, 0), shape[2].Position);
            Assert.AreEqual(new Point(5, 1), shape[3].Position);
        }
    }
}
