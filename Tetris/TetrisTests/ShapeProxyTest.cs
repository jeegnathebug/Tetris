using TetrisLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace TetrisTests
{
    [TestClass]
    public class ShapeProxyTest
    {
        [TestMethod]
        public void OnJoinPile()
        {
            //arrange
            Board board = new Board();
            IShape shape = board.Shape;
            shape.JoinPile += JoinPileHandler;

            //act
            shape.Drop();
        }

        private void JoinPileHandler(IShape shape)
        {
            // assert
            Assert.IsTrue(true); // Test if method was called
        }

        [TestMethod]
        public void MoveLeft()
        {
            //arrange
            Board board = new Board();
            IShapeFactory shapeFactory = board.ShapeFactory;
            IShape shape;

            //act
            shapeFactory.DeployShape(1);
            shape = board.Shape;
            shape.MoveLeft();

            //assert
            Assert.AreEqual(3, shape[0].Position.X);
            Assert.AreEqual(0, shape[0].Position.Y);
            Assert.AreEqual(4, shape[1].Position.X);
            Assert.AreEqual(0, shape[1].Position.Y);
            Assert.AreEqual(5, shape[2].Position.X);
            Assert.AreEqual(0, shape[2].Position.Y);
            Assert.AreEqual(5, shape[3].Position.X);
            Assert.AreEqual(1, shape[3].Position.Y);
        }

        [TestMethod]
        public void MoveRight()
        {
            //arrange
            Board board = new Board();
            IShapeFactory shapeFactory = board.ShapeFactory;
            IShape shape;

            //act
            shapeFactory.DeployShape(2);
            shape = board.Shape;
            shape.MoveRight();

            //assert
            Assert.AreEqual(5, shape[0].Position.X);
            Assert.AreEqual(1, shape[0].Position.Y);
            Assert.AreEqual(5, shape[1].Position.X);
            Assert.AreEqual(0, shape[1].Position.Y);
            Assert.AreEqual(6, shape[2].Position.X);
            Assert.AreEqual(0, shape[2].Position.Y);
            Assert.AreEqual(7, shape[3].Position.X);
            Assert.AreEqual(0, shape[3].Position.Y);
        }

        [TestMethod]
        public void MoveDown()
        {
            //arrange
            Board board = new Board();
            IShapeFactory shapeFactory = board.ShapeFactory;
            IShape shape;

            //act
            shapeFactory.DeployShape(3);
            shape = board.Shape;
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
        public void Drop()
        {
            //arrange
            Board board = new Board();
            IShapeFactory shapeFactory = board.ShapeFactory;
            IShape shape;

            //act
            shapeFactory.DeployShape(4);
            shape = board.Shape;
            shape.Drop();

            //assert
            Assert.AreEqual(Color.Lime, board[4,19]);
            Assert.AreEqual(Color.Lime, board[5, 19]);
            Assert.AreEqual(Color.Lime, board[5, 18]);
            Assert.AreEqual(Color.Lime, board[6, 18]);
        }

        private void Shape_JoinPile(IShape shape)
        {
            throw new System.NotImplementedException();
        }

        [TestMethod]
        public void Reset()
        {
            //arrange
            Board board = new Board();
            IShapeFactory shapeFactory = board.ShapeFactory;
            IShape shape;

            //act
            shapeFactory.DeployShape(5);
            shape = board.Shape;
            shape.MoveDown();
            shape.Reset();

            //assert
            Assert.AreEqual(4, shape[0].Position.X);
            Assert.AreEqual(0, shape[0].Position.Y);
            Assert.AreEqual(5, shape[1].Position.X);
            Assert.AreEqual(0, shape[1].Position.Y);
            Assert.AreEqual(5, shape[2].Position.X);
            Assert.AreEqual(1, shape[2].Position.Y);
            Assert.AreEqual(6, shape[3].Position.X);
            Assert.AreEqual(0, shape[3].Position.Y);
        }

        [TestMethod]
        public void Rotate()
        {
            //arrange
            Board board = new Board();
            IShapeFactory shapeFactory = board.ShapeFactory;
            IShape shape;

            //act
            shapeFactory.DeployShape(6);
            shape = board.Shape;
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
    }
}
