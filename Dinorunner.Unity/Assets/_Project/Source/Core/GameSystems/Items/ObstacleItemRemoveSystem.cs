using System;
using NickoJ.DinoRunner.Core.Model;

namespace NickoJ.DinoRunner.Core.GameSystems.Items
{
    /// <summary>
    /// Removes obstacles if they are out of the game field.
    /// </summary>
    internal sealed class ObstacleItemRemoveSystem: GameSystem, IUpdateGameSystem
    {
        private readonly GameState _state;

        public ObstacleItemRemoveSystem(GameState state, ILogger logger = null) : base(false, logger)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));

            _state.OnGameStarted += GameStartedHandler;
        }

        void IUpdateGameSystem.Update(float dt)
        {
            GameField field = _state.GameField;
            int count = field.OnFieldObstacleCount;

            for (int i = count - 1; i >= 0; --i)
            {
                ObstacleItem item = field.GetRefObstacleByIndex(i);

                if (item.Pos < -1)
                {
                    field.RemoveObstacleByIndex(i);
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