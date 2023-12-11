using System;

namespace NickoJ.DinoRunner.Core.Model
{
    /// <summary>
    /// Interface of game state for external usage.
    /// </summary>
    public interface IGameState
    {
        public bool Started { get; }

        Player Player { get; }
        GameScore Score { get; }
        GameField GameField { get; }

        public event Action<bool> OnGameStarted;
    }
}