namespace NickoJ.DinoRunner.Core.GameSystems
{
    /// <summary>
    /// Implement this interface for your game system to detect every system tick.
    /// </summary>
    internal interface IUpdateGameSystem
    {
        void Update(float dt);
    }
}