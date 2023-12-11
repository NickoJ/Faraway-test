using System;
using NickoJ.DinoRunner.Core.GameSystems.Score;

namespace NickoJ.DinoRunner.Core.Model
{
    public interface IGameState
    {
        public bool Started { get; }

        Player Player { get; }
        GameScore Score { get; }
        GameField GameField { get; }

        public event Action<bool> OnGameStarted;
    }
}