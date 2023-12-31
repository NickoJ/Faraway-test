﻿using System;
using NickoJ.DinoRunner.Core.Model;

namespace NickoJ.DinoRunner.Core.GameSystems.Items
{
    /// <summary>
    /// Remove bonus items if they are out of game field.
    /// </summary>
    internal sealed class BonusItemRemoveSystem : GameSystem, IUpdateGameSystem
    {
        private readonly GameState _state;

        public BonusItemRemoveSystem(GameState state, ILogger logger = null) : base(false, logger)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));

            _state.OnGameStarted += GameStartedHandler;
        }

        void IUpdateGameSystem.Update(float dt)
        {
            GameField field = _state.GameField;
            int count = field.OnFieldBonusCount;

            for (int i = count - 1; i >= 0; --i)
            {
                BonusItem bonus = field.GetRefBonusByIndex(i);

                if (bonus.Pos < -1)
                {
                    field.RemoveBonusByIndex(i);
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