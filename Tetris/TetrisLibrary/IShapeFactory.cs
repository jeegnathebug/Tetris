namespace TetrisLibrary
{
    interface IShapeFactory
    {
        /// <summary>
        /// Deploys a new <see cref="TetrisLibrary.Shape"/> instance.
        /// </summary>
        void DeployNewShape();
    }
}
