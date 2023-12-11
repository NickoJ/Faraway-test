using System;
using System.Collections.Generic;
using NickoJ.DinoRunner.Core.Config;
using NickoJ.DinoRunner.Core.Model;
using NickoJ.DinoRunner.Core.Model.Bonuses;

namespace NickoJ.DinoRunner.Core.GameSystems.Items
{
    /// <summary>
    /// Generates bonus items during the run.
    /// </summary>
    internal sealed class BonusItemGenerateSystem : GameSystem, IInitGameSystem, IUpdateGameSystem
    {
        private readonly GameState _state;
        private readonly IBonusGeneratorConfig _config;
        private readonly Random _random;

        private float _distanceToBonus;
        
        public BonusItemGenerateSystem(GameState state, IBonusGeneratorConfig config, ILogger logger = null) 
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
                
                BonusKind? kind = GetRandomBonusKind();
                
                if (kind == null) return;

                float pos = _config.SpawnDistance;

                _state.GameField.AddBonus(kind.Value, pos);
            }
        }

        private void UpdateDistance()
        {
            float min = _config.SpawnIntervalMin;
            float max = _config.SpawnIntervalMax;

            _distanceToBonus = min + (float) _random.NextDouble() * (max - min);
        }

        private BonusKind? GetRandomBonusKind()
        {
            var weight = 0f;
            BonusKind? kind = null;

            foreach (KeyValuePair<BonusKind, float> kvp in _config.SpawnChances)
            {
                weight += kvp.Value;

                if (_random.NextDouble() < kvp.Value / weight)
                {
                    kind = kvp.Key;
                }
            }

            return kind;
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