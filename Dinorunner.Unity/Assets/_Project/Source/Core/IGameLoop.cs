namespace NickoJ.DinoRunner.Core
{
    /// <summary>
    /// Interface of game loop that needs to be implemented on the engine side.
    /// (Dependency inversion)
    /// </summary>
    public interface IGameLoop
    {
        public delegate void TickDelegate(float dt);
        
        event TickDelegate OnTick;
    }
}