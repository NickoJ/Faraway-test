using System;
using NickoJ.DinoRunner.Core.Config;
using NickoJ.DinoRunner.Core.GameSystems.Bonuses;
using NickoJ.DinoRunner.Core.Model;

namespace NickoJ.DinoRunner.Core.GameSystems.Items
{
    /// <summary>
    /// Detects collision of the player and bonuses and sends it for activation.
    /// </summary>
    internal sealed class BonusItemCollisionSystem : GameSystem, IUpdateGameSystem
    {
        private readonly GameState _state;
        private readonly IBonusSystem _bonusSystem;
        private readonly IPlayerConfig _playerConfig;
        private readonly IBonusesConfig _bonusesConfig;

        public BonusItemCollisionSystem
        (
            GameState state,
            IBonusSystem bonusSystem,
            IPlayerConfig playerConfig,
            IBonusesConfig bonusesConfig,
            ILogger logger = null
        ) : base(false, logger)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
            _bonusSystem = bonusSystem ?? throw new ArgumentNullException(nameof(bonusSystem));
            _playerConfig = playerConfig ?? throw new ArgumentNullException(nameof(playerConfig));
            _bonusesConfig = bonusesConfig ?? throw new ArgumentNullException(nameof(bonusesConfig));

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

            float byMin = _bonusesConfig.MinY;
            float byMax = _bonusesConfig.MaxY;
            
            for (int i = 0; i < bonusCount; ++i)
            {
                BonusItem bonus = _state.GameField.GetBonusByIndex(i);

                float bxMin = bonus.Pos - _bonusesConfig.Width / 2f;
                float bxMax = bxMin + _bonusesConfig.Width;

                if (bxMin < pxMax && bxMax > pxMin && pyMin < byMax && pyMax > byMin)
                {
                    _state.GameField.RemoveBonusByIndex(i);
                    _bonusSystem.AddBonus(bonus.Kind);
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