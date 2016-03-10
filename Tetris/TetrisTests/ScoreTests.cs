using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TetrisLibrary;

namespace TetrisTests
{
    [TestClass]
    public class ScoreTests
    { 
        [TestMethod]
        public void Score_100()
        {
            //arrange
			Board board = new Board();
			IShapeFactory shapeFactory = board.ShapeFactory;
			IShape shape;
			Score score = new Score(board);

            //act
			shapeFactory.DeployShape(3);
			shape = board.Shape;
			shape.MoveLeft();
			shape.MoveLeft();
			shape.MoveLeft();
			shape.MoveLeft();
			shape.Drop();

			shapeFactory.DeployShape(3);
			shape = board.Shape();
			shape.MoveLeft();
			shape.MoveLeft();
			shape.Drop();

			shapeFactory.DeployShape(3);
			shape = board.Shape();
			shape.Drop();

			shapeFactory.DeployShape(3);
			shape = board.Shape();
			shape.MoveRight();
			shape.MoveRight();
			shape.Drop();

			shapeFactory.DeployShape(3);
			shape = board.Shape();
			shape.MoveRight();
			shape.MoveRight();
			shape.MoveRight();
			shape.MoveRight();
			shape.Drop();

			//assert			
			Assert.AreEqual(200, score.score);
			Assert.AreEqual(2, score.Lines);
			Assert.AreEqual(2, score.Level);
        }

		[TestMethod]
		public void Score_400()
		{
			//arrange
			Board board = new Board();
			IShapeFactory shapeFactory = board.ShapeFactory;
			IShape shape;
			Score score = new Score(board);

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
			Assert.AreEqual(800, score.score);
			Assert.AreEqual(4, score.Lines);
			Assert.AreEqual(4, score.Level);
		}
    }
}
