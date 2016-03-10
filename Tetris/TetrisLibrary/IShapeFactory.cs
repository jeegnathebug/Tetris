namespace TetrisLibrary
{
    public interface IShapeFactory
    {
        /// <summary>
        /// Deploys a new <see cref="Shape"/> instance.
        /// </summary>
        void DeployNewShape();
    }
}
