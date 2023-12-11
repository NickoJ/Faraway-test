using NickoJ.DinoRunner.Core.Model;

namespace NickoJ.DinoRunner.Core
{
    public interface IGame
    {
        IGameState State { get; }
        
        void Start();
    }
}