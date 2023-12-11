using System;
using NickoJ.DinoRunner.Core.Config;
using NickoJ.DinoRunner.Core.GameSystems;
using NickoJ.DinoRunner.Core.GameSystems.Bonuses;
using NickoJ.DinoRunner.Core.GameSystems.Gravity;
using NickoJ.DinoRunner.Core.GameSystems.Items;
using NickoJ.DinoRunner.Core.GameSystems.PlayerMovement;
using NickoJ.DinoRunner.Core.GameSystems.Score;
using NickoJ.DinoRunner.Core.Model;
using NickoJ.DinoRunner.Core.Model.Bonuses;

namespace NickoJ.DinoRunner.Core
{
    public sealed class Game : IGame, IDisposable
    {
        private readonly IGameLoop _gameLoop;

        private readonly GameSystem[] _gameSystems;

        private GameState _state;

        public IGameState State => _state;

        public Game(IGameLoop gameLoop, ILogger logger, IGameConfig gameConfig)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));

            _state = new GameState
            (
                new Player(gameConfig.Player), 
                new GameScore(),
                new GameField(gameConfig.GameField)
            );

            var bonusSystem = new BonusSystem(new BonusStorage(_state.Player, gameConfig.Bonuses));
            
            _gameSystems = new GameSystem[]
            {
                bonusSystem,
                new GravitySystem(_state.Player, gameConfig.Gravity),
                new RunSystem(_state, gameConfig.Run),
                new ValidateSpeedSystem(_state),
                new BonusItemGenerateSystem(_state, gameConfig.BonusGeneratorConfig, logger),
                new BonusItemsMoveSystem(_state, logger),
                new BonusItemCollisionSystem(_state, bonusSystem, gameConfig.Player, gameConfig.Bonuses, logger ),
                new BonusItemRemoveSystem(_state, logger),
                new ObstacleItemGenerateSystem(_state, gameConfig.ObstacleGeneratorConfig, logger),
                new ObstacleItemsMoveSystem(_state, logger),
                new ObstacleItemRemoveSystem(_state, logger),
                new CalculateScoreSystem(_state)
            };
            
            _gameLoop.OnTick += Tick;
        }

        public void Start()
        {
            if (_state.Started) return;

            _state.Started = true;
        }

        public T GetSystem<T>() where T : class, IGameSystem
        {
            foreach (GameSystem system in _gameSystems)
            {
                if (system is T casted)
                {
                    return casted;
                }
            }

            return null;
        }

        private void Tick(float dt)
        {
            foreach (GameSystem system in _gameSystems)
            {
                system.Tick(dt);
            }
        }

        public void Dispose()
        {
            _gameLoop.OnTick -= Tick;
        }
    }
}