namespace NickoJ.DinoRunner.Engine
{
    /// <summary>
    /// Interface for service locator.
    /// </summary>
    public interface IServiceLocator
    {
        /// <summary>
        /// Return instance of T
        /// </summary>
        /// <typeparam name="T">Type of a looking instance.</typeparam>
        /// <returns></returns>
        public T Get<T>();
   }
}