using System;
using NickoJ.DinoRunner.Core.Model;

namespace NickoJ.DinoRunner.Core.GameSystems
{
    internal sealed class CheckDeathSystem : GameSystem, IInitGameSystem, IUpdateGameSystem, IFinishGameSystem
    {
        private readonly GameState _state;

        public CheckDeathSystem(GameState state, ILogger logger = null) : base(false, logger)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));

            _state.OnGameStarted += GameStartedHandler;
        }

        void IInitGameSystem.Init()
        {
            _state.Player.IsDead = false;
        }

        void IUpdateGameSystem.Update(float dt)
        {
            if (_state.Player.IsDead)
            {
                Stop();
            }
        }

        void IFinishGameSystem.Finish()
        {
            _state.Started = false;
        }

        private void GameStartedHandler(bool started)
        {
            if (started)
            {
                Start();
            }
        }
    }
}