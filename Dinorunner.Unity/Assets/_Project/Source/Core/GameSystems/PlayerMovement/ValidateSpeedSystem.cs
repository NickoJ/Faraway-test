using System;
using NickoJ.DinoRunner.Core.Model;

namespace NickoJ.DinoRunner.Core.GameSystems.PlayerMovement
{
    /// <summary>
    /// Validates player speed if it's invalidated.
    /// </summary>
    internal sealed class ValidateSpeedSystem : GameSystem, IInitGameSystem, IUpdateGameSystem, IFinishGameSystem
    {
        private readonly IGameState _gameState;

        public ValidateSpeedSystem(IGameState gameState) : base(false)
        {
            _gameState = gameState ?? throw new ArgumentNullException(nameof(gameState));

            _gameState.OnGameStarted += GameStartedHandler;
        }

        void IInitGameSystem.Init()
        {
            _gameState.Player.CanStop = false;
        }

        void IUpdateGameSystem.Update(float dt)
        {
            _gameState.Player.Validate();
        }

        void IFinishGameSystem.Finish()
        {
            _gameState.Player.CanStop = true;
            _gameState.Player.Validate();
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