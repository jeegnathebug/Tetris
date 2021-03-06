﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TetrisLibrary;
using System.Drawing;

namespace TetrisTests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void ValidConstructor()
        {
            //arrange
            IBoard board = new Board();

            //assert
            Assert.IsInstanceOfType(board, typeof(IBoard));
        }

        [TestMethod]
        public void GetLength()
        {
            //arrange
            IBoard board = new Board();

            //act
            int dim1 = board.GetLength(0);
            int dim2 = board.GetLength(1);

            //assert
            Assert.AreEqual(10, dim1);
            Assert.AreEqual(20, dim2);
        }

        [TestMethod]
        public void DropsLines()
        {
            //arrange
            Board board = new Board();
            IShapeFactory shapeFactory = board.ShapeFactory;
            IShape shape;

            //act
            shapeFactory.DeployShape(0);
            shape = board.Shape;
            shape.MoveDown();
            shape.Rotate();
            shape.MoveLeft();
            shape.MoveLeft();
            shape.MoveLeft();
            shape.MoveLeft();
            shape.MoveLeft();
            shape.Drop();

            shapeFactory.DeployShape(0);
            shape = board.Shape;
            shape.MoveDown();
            shape.Rotate();
            shape.MoveLeft();
            shape.MoveLeft();
            shape.MoveLeft();
            shape.MoveLeft();
            shape.Drop();

            shapeFactory.DeployShape(0);
            shape = board.Shape;
            shape.MoveDown();
            shape.Rotate();
            shape.MoveLeft();
            shape.MoveLeft();
            shape.MoveLeft();
            shape.Drop();

            shapeFactory.DeployShape(0);
            shape = board.Shape;
            shape.MoveDown();
            shape.Rotate();
            shape.MoveLeft();
            shape.MoveLeft();
            shape.Drop();

            shapeFactory.DeployShape(0);
            shape = board.Shape;
            shape.MoveDown();
            shape.Rotate();
            shape.MoveLeft();
            shape.Drop();

            shapeFactory.DeployShape(0);
            shape = board.Shape;
            shape.MoveDown();
            shape.Rotate();
            shape.Drop();

            shapeFactory.DeployShape(0);
            shape = board.Shape;
            shape.MoveDown();
            shape.Rotate();
            shape.MoveRight();
            shape.Drop();

            shapeFactory.DeployShape(0);
            shape = board.Shape;
            shape.MoveDown();
            shape.Rotate();
            shape.MoveRight();
            shape.MoveRight();
            shape.Drop();

            shapeFactory.DeployShape(0);
            shape = board.Shape;
            shape.MoveDown();
            shape.Rotate();
            shape.MoveRight();
            shape.MoveRight();
            shape.MoveRight();
            shape.Drop();

            // Shape placed on top of the pile to be cleared
            // Should be dropped to bottom of board
            shapeFactory.DeployShape(0);
            shape = board.Shape;
            shape.Drop();

            shapeFactory.DeployShape(0);
            shape = board.Shape;
            shape.MoveDown();
            shape.Rotate();
            shape.MoveRight();
            shape.MoveRight();
            shape.MoveRight();
            shape.MoveRight();
            shape.Drop();

            //assert
            Assert.IsTrue(board[3, 19] == Color.Cyan);
            Assert.IsTrue(board[4, 19] == Color.Cyan);
            Assert.IsTrue(board[5, 19] == Color.Cyan);
            Assert.IsTrue(board[6, 19] == Color.Cyan);
        }

        [TestMethod]
        public void DropsLines2()
        {
            //arrange
            Board board = new Board();
            IShapeFactory shapeFactory = board.ShapeFactory;
            IShape shape;

            //act
            board[0, 19] = Color.Red;
            board[1, 19] = Color.Red;
            board[2, 19] = Color.Red;
            board[3, 19] = Color.Red;
            board[6, 19] = Color.Red;
            board[7, 19] = Color.Red;
            board[8, 19] = Color.Red;
            board[9, 19] = Color.Red;

            board[0, 18] = Color.Red;
            board[2, 18] = Color.Red;
            board[3, 18] = Color.Red;
            board[7, 18] = Color.Red;
            board[8, 18] = Color.Red;

            board[0, 17] = Color.Red;
            board[1, 17] = Color.Red;
            board[2, 17] = Color.Red;
            board[3, 17] = Color.Red;
            board[6, 17] = Color.Red;
            board[7, 17] = Color.Red;
            board[8, 17] = Color.Red;
            board[9, 17] = Color.Red;

            board[0, 16] = Color.Red;
            board[2, 16] = Color.Red;
            board[3, 16] = Color.Red;
            board[7, 16] = Color.Red;
            board[8, 16] = Color.Red;

            shapeFactory.DeployShape(0);
            shape = board.Shape;
            shape.MoveDown();
            shape.Rotate();
            shape.MoveLeft();
            shape.Drop();

            shapeFactory.DeployShape(0);
            shape = board.Shape;
            shape.MoveDown();
            shape.Rotate();
            shape.Drop();

            //assert
            Assert.IsTrue(board[0, 19] == Color.Red);
            Assert.IsTrue(board[0, 18] == Color.Red);
            Assert.IsTrue(board[2, 19] == Color.Red);
            Assert.IsTrue(board[2, 18] == Color.Red);
            Assert.IsTrue(board[3, 19] == Color.Red);
            Assert.IsTrue(board[3, 18] == Color.Red);
            Assert.IsTrue(board[7, 19] == Color.Red);
            Assert.IsTrue(board[7, 18] == Color.Red);
            Assert.IsTrue(board[8, 19] == Color.Red);
            Assert.IsTrue(board[8, 18] == Color.Red);
        }

        [TestMethod]
        public void OnLinesCleared()
        {
            //arrange
            Board board = new Board();
            IShapeFactory shapeFactory = board.ShapeFactory;
            IShape shape;

            // add event handler
            board.LinesCleared += LinesClearedHandler;

            //act
            shapeFactory.DeployShape(3);
            shape = board.Shape;
            shape.MoveLeft();
            shape.MoveLeft();
            shape.MoveLeft();
            shape.MoveLeft();
            shape.Drop();

            shapeFactory.DeployShape(3);
            shape = board.Shape;
            shape.MoveLeft();
            shape.MoveLeft();
            shape.Drop();

            shapeFactory.DeployShape(3);
            shape = board.Shape;
            shape.Drop();

            shapeFactory.DeployShape(3);
            shape = board.Shape;
            shape.MoveRight();
            shape.MoveRight();
            shape.Drop();

            shapeFactory.DeployShape(3);
            shape = board.Shape;
            shape.MoveRight();
            shape.MoveRight();
            shape.MoveRight();
            shape.MoveRight();
            shape.Drop();
        }

        private void LinesClearedHandler(int num)
        {
            // Assert - test if this method was called with right value
            Assert.AreEqual(2, num);
        }

        [TestMethod]
        public void OnGameOver()
        {
            //arrange
            Board board = new Board();
            IShapeFactory shapeFactory = board.ShapeFactory;
            IShape shape;

            // add event handler
            board.GameOver += GameOverHandler;

            //act
            shapeFactory.DeployShape(3);
            shape = board.Shape;
            shape.Drop();

            shapeFactory.DeployShape(3);
            shape = board.Shape;
            shape.Drop();

            shapeFactory.DeployShape(3);
            shape = board.Shape;
            shape.Drop();

            shapeFactory.DeployShape(3);
            shape = board.Shape;
            shape.Drop();

            shapeFactory.DeployShape(3);
            shape = board.Shape;
            shape.Drop();

            shapeFactory.DeployShape(3);
            shape = board.Shape;
            shape.Drop();

            shapeFactory.DeployShape(3);
            shape = board.Shape;
            shape.Drop();

            shapeFactory.DeployShape(3);
            shape = board.Shape;
            shape.Drop();

            shapeFactory.DeployShape(3);
            shape = board.Shape;
            shape.Drop();

            shapeFactory.DeployShape(3);
            shape = board.Shape;
            shape.Drop();

            // Should not work
            shapeFactory.DeployShape(3);
            shape = board.Shape;
            shape.Drop();
        }

        private void GameOverHandler()
        {
            // Assert - test if this method was called
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void AddToPile()
        {
            //arrange
            Board board = new Board();
            IShapeFactory shapeFactory = board.ShapeFactory;
            IShape shape;

            //act
            shapeFactory.DeployShape(3);
            shape = board.Shape;
            shape.Drop();

            //assert
            Assert.IsTrue(board[4, 18].Equals(Color.Yellow));
            Assert.IsTrue(board[5, 18].Equals(Color.Yellow));
            Assert.IsTrue(board[4, 19].Equals(Color.Yellow));
            Assert.IsTrue(board[5, 19].Equals(Color.Yellow));
        }
    }
}
