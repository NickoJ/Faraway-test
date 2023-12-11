namespace NickoJ.DinoRunner.Core
{
    /// <summary>
    /// Interface of the logger that need to be implemented on the engine side.
    /// (Dependency inversion)
    /// </summary>
    public interface ILogger
    {
        public void Log(string message);
    }
}