using System;
using NickoJ.DinoRunner.Core.Config;
using NickoJ.DinoRunner.Core.GameSystems.Bonuses;
using NickoJ.DinoRunner.Core.Model;

namespace NickoJ.DinoRunner.Core.GameSystems.Items
{
    internal sealed class ObstacleItemCollisionSystem : GameSystem, IUpdateGameSystem
    {
        private readonly GameState _state;
        private readonly IPlayerConfig _playerConfig;
        private readonly IObstacleConfig _obstacleConfig;

        public ObstacleItemCollisionSystem
        (
            GameState state,
            IPlayerConfig playerConfig,
            IObstacleConfig obstacleConfig,
            ILogger logger = null
        ) : base(false, logger)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
            _playerConfig = playerConfig ?? throw new ArgumentNullException(nameof(playerConfig));
            _obstacleConfig = obstacleConfig ?? throw new ArgumentNullException(nameof(obstacleConfig));

            _state.OnGameStarted += GameStartedHandler;
        }

        void IUpdateGameSystem.Update(float dt)
        {
            float pw = _playerConfig.Width;
            float ph = _playerConfig.Height;

            float pxMin = _playerConfig.X -pw / 2f;
            float pxMax = pxMin + pw;
            float pyMin = _state.Player.Y;
            float pyMax = pyMin + ph;

            int bonusCount = _state.GameField.OnFieldBonusCount;

            float byMin = _obstacleConfig.MinY;
            float byMax = _obstacleConfig.MaxY;
            
            for (int i = 0; i < bonusCount; ++i)
            {
                BonusItem bonus = _state.GameField.GetBonusByIndex(i);

                float bxMin = bonus.Pos - _obstacleConfig.Width / 2f;
                float bxMax = bxMin + _obstacleConfig.Width;

                if (bxMin < pxMax && bxMax > pxMin && pyMin < byMax && pyMax > byMin)
                {
                    _state.GameField.RemoveBonusByIndex(i);
                    _state.Player.IsDead = true;
                }
            }
        }

        private void GameStartedHandler(bool started)
        {
            if (started)
            {
                Start();
            }
            else
            {
                Stop();
            }
        }
    }
}