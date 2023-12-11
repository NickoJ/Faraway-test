using System;
using NickoJ.DinoRunner.Core.GameSystems.Score;

namespace NickoJ.DinoRunner.Core.Model
{
    internal sealed class GameState : IGameState
    {
        private bool _started;
        private Player _player;

        public bool Started
        {
            get => _started;
            set
            {
                if (_started == value) return;

                _started = value;
                OnGameStarted?.Invoke(_started);
            }
        }

        public Player Player { get; }
        public GameScore Score { get; }
        public GameField GameField { get; }

        public event Action<bool> OnGameStarted;

        public GameState(Player player, GameScore score, GameField gameField)
        {
            Player = player ?? throw new ArgumentNullException(nameof(player));
            Score = score ?? throw new ArgumentNullException(nameof(score));
            GameField = gameField ?? throw new ArgumentNullException(nameof(gameField));
        }
    }
}