using NickoJ.DinoRunner.Core.Model;

namespace NickoJ.DinoRunner.Core
{
    /// <summary>
    /// public interface of the game for other assemblies.
    /// </summary>
    public interface IGame
    {
        IGameState State { get; }
        
        void Start();
    }
}