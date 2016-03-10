namespace TetrisLibrary
{
    public interface IShapeFactory
    {
        /// <summary>
        /// Deploys a new <see cref="Shape"/> instance.
        /// </summary>
        void DeployNewShape();
        
        /// <summary>
        /// Deploys a new <see cref="Shape"/> instance with a given number.
        /// </summary>
        void DeployShape(int num);
    }
}
