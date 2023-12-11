using System;
using NickoJ.DinoRunner.Core.Model;

namespace NickoJ.DinoRunner.Core.GameSystems.Items
{
    internal sealed class BonusItemsMoveSystem : GameSystem, IUpdateGameSystem
    {
        private readonly GameState _state;

        public BonusItemsMoveSystem(GameState state, ILogger logger = null) : base(false, logger)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));

            _state.OnGameStarted += GameStartedHandler;
        }

        void IUpdateGameSystem.Update(float dt)
        {
            GameField field = _state.GameField;
            int bonusCount = field.OnFieldBonusCount;

            for (int i = 0; i < bonusCount; i++)
            {
                ref BonusItem bonusItem = ref field.GetRefBonusByIndex(i);

                bonusItem.Pos -= _state.Player.CurrentSpeed * dt;
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