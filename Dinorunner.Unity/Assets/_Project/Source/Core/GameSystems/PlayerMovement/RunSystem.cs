using System;
using NickoJ.DinoRunner.Core.Config;
using NickoJ.DinoRunner.Core.Model;

namespace NickoJ.DinoRunner.Core.GameSystems.PlayerMovement
{
    internal sealed class RunSystem : GameSystem, IInitGameSystem, IUpdateGameSystem, IFinishGameSystem
    {
        private readonly IGameState _gameState;
        private readonly IRunConfig _runConfig;

        private float _timer;

        public RunSystem(IGameState gameState, IRunConfig runConfig) : base(false)
        {
            _gameState = gameState;
            _runConfig = runConfig;

            _gameState.OnGameStarted += GameStartedHandler;
        }

        void IInitGameSystem.Init()
        {
            _timer = 0f;
        }

        void IUpdateGameSystem.Update(float dt)
        {
            _timer += dt;

            float timeValue = Math.Clamp(_timer, 0, _runConfig.AccelerationTime) / _runConfig.AccelerationTime;
            float speed = _runConfig.MinSpeed + timeValue * (_runConfig.MaxSpeed -_runConfig.MinSpeed);

            _gameState.Player.BaseSpeed = speed;
        }

        void IFinishGameSystem.Finish()
        {
            _gameState.Player.BaseSpeed = 0f;
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