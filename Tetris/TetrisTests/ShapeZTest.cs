﻿using TetrisLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TetrisTests
{
    [TestClass]
    public class ShapeZTest
    {
          [TestMethod]
        public void TestMethodShapeZ_MoveLeft()
        {
            //arrange
            IBoard board = new Board();
            ShapeZ shape = new ShapeZ(board);

            //act
            shape.MoveLeft();

            //assert
            Assert.AreEqual(3, shape[0].Position.X);
            Assert.AreEqual(0, shape[0].Position.Y);
            Assert.AreEqual(4, shape[1].Position.X);
            Assert.AreEqual(0, shape[1].Position.Y);
            Assert.AreEqual(4, shape[2].Position.X);
            Assert.AreEqual(1, shape[2].Position.Y);
            Assert.AreEqual(5, shape[3].Position.X);
            Assert.AreEqual(1, shape[3].Position.Y);
        }

        [TestMethod]
        public void TestMethodShapeZ_MoveRight()
        {
            //arrange
            IBoard board = new Board();
            ShapeZ shape = new ShapeZ(board);

            //act
            shape.MoveRight();

            //assert
            Assert.AreEqual(5, shape[0].Position.X);
            Assert.AreEqual(0, shape[0].Position.Y);
            Assert.AreEqual(6, shape[1].Position.X);
            Assert.AreEqual(0, shape[1].Position.Y);
            Assert.AreEqual(6, shape[2].Position.X);
            Assert.AreEqual(1, shape[2].Position.Y);
            Assert.AreEqual(7, shape[3].Position.X);
            Assert.AreEqual(1, shape[3].Position.Y);
        }

        [TestMethod]
        public void TestMethodShapeZ_MoveDown()
        {
            //arrange
            IBoard board = new Board();
            ShapeZ shape = new ShapeZ(board);

            //act
            shape.MoveDown();

            //assert
            Assert.AreEqual(4, shape[0].Position.X);
            Assert.AreEqual(1, shape[0].Position.Y);
            Assert.AreEqual(5, shape[1].Position.X);
            Assert.AreEqual(1, shape[1].Position.Y);
            Assert.AreEqual(5, shape[2].Position.X);
            Assert.AreEqual(2, shape[2].Position.Y);
            Assert.AreEqual(6, shape[3].Position.X);
            Assert.AreEqual(2, shape[3].Position.Y);
        }

        [TestMethod]
        public void TestMethodShapeZ_Rotate()
        {
            //arrange
            IBoard board = new Board();
            ShapeZ shape = new ShapeZ(board);

            //act
            shape.MoveDown();
            shape.Rotate();

            //assert
            Assert.AreEqual(5, shape[0].Position.X);
            Assert.AreEqual(2, shape[0].Position.Y);
            Assert.AreEqual(5, shape[1].Position.X);
            Assert.AreEqual(1, shape[1].Position.Y);
            Assert.AreEqual(6, shape[2].Position.X);
            Assert.AreEqual(1, shape[2].Position.Y);
            Assert.AreEqual(6, shape[3].Position.X);
            Assert.AreEqual(0, shape[3].Position.Y);
        }

        [TestMethod]
        public void TestMethodShapeZ_Rotate2()
        {
            //arrange
            IBoard board = new Board();
            ShapeZ shape = new ShapeZ(board);

            //act
            shape.MoveDown();
            shape.Rotate();
            shape.Rotate();

            //assert
            Assert.AreEqual(4, shape[0].Position.X);
            Assert.AreEqual(1, shape[0].Position.Y);
            Assert.AreEqual(5, shape[1].Position.X);
            Assert.AreEqual(1, shape[1].Position.Y);
            Assert.AreEqual(5, shape[2].Position.X);
            Assert.AreEqual(2, shape[2].Position.Y);
            Assert.AreEqual(6, shape[3].Position.X);
            Assert.AreEqual(2, shape[3].Position.Y);
        }

        [TestMethod]
        public void TestMethodShapeZ_Drop()
        {
            //arrange
            IBoard board = new Board();
            ShapeZ shape = new ShapeZ(board);

            //act
            shape.Drop();

            //assert
            Assert.AreEqual(4, shape[0].Position.X);
            Assert.AreEqual(18, shape[0].Position.Y);
            Assert.AreEqual(5, shape[1].Position.X);
            Assert.AreEqual(18, shape[1].Position.Y);
            Assert.AreEqual(5, shape[2].Position.X);
            Assert.AreEqual(19, shape[2].Position.Y);
            Assert.AreEqual(6, shape[3].Position.X);
            Assert.AreEqual(19, shape[3].Position.Y);
        }

        [TestMethod]
        public void TestMethodShapeZ_Reset()
        {
            //arrange
            IBoard board = new Board();
            ShapeZ shape = new ShapeZ(board);

            shape.MoveDown();

            //act
            shape.Reset();

            //assert
            Assert.AreEqual(4, shape[0].Position.X);
            Assert.AreEqual(0, shape[0].Position.Y);
            Assert.AreEqual(5, shape[1].Position.X);
            Assert.AreEqual(0, shape[1].Position.Y);
            Assert.AreEqual(5, shape[2].Position.X);
            Assert.AreEqual(1, shape[2].Position.Y);
            Assert.AreEqual(6, shape[3].Position.X);
            Assert.AreEqual(1, shape[3].Position.Y);
        }
    }
}
