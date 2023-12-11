using System;
using NickoJ.DinoRunner.Core.Config;
using NickoJ.DinoRunner.Core.Model;

namespace NickoJ.DinoRunner.Core.GameSystems.Items
{
    /// <summary>
    /// Generates obstacles during the run.
    /// </summary>
    internal sealed class ObstacleItemGenerateSystem : GameSystem, IInitGameSystem, IUpdateGameSystem
    {
        private readonly GameState _state;
        private readonly IObstacleGeneratorConfig _config;
        private readonly Random _random;

        private float _distanceToBonus;
        
        public ObstacleItemGenerateSystem(GameState state, IObstacleGeneratorConfig config, ILogger logger = null) 
            : base(false, logger)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
            _config = config ?? throw new ArgumentNullException(nameof(config));

            _random = new Random();

            _state.OnGameStarted += GameStartedHandler;
        }

        void IInitGameSystem.Init()
        {
            UpdateDistance();
        }

        void IUpdateGameSystem.Update(float dt)
        {
            _distanceToBonus -= dt * _state.Player.CurrentSpeed;

            if (_distanceToBonus <= 0)
            {
                UpdateDistance();

                if (!_state.GameField.CanAddBonus()) return;
                
                float pos = _config.SpawnDistance;

                _state.GameField.AddObstacle(pos);
            }
        }

        private void UpdateDistance()
        {
            float min = _config.SpawnIntervalMin;
            float max = _config.SpawnIntervalMax;

            _distanceToBonus = min + (float) _random.NextDouble() * (max - min);
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