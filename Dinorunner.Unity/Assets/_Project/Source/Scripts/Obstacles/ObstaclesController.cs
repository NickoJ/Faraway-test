using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using NickoJ.DinoRunner.Core.Model;
using UnityEngine;

namespace NickoJ.DinoRunner.Scripts.Obstacles
{
    /// <summary>
    /// Binds obstacle item views with model.
    /// </summary>
    public sealed class ObstaclesController
    {
        private readonly IGameState _state;
        private readonly IObstacleViewsStorage _storage;

        private readonly Dictionary<uint, IObstacleItemView> _viewById = new();

        public ObstaclesController(IGameState state, IObstacleViewsStorage storage)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));

            _state.GameField.OnObstacleAdded += ObstacleAddedHandler;
            _state.GameField.OnObstacleRemoved += ObstacleRemovedHandler;

            _state.OnGameStarted += GameStartedHandler;
        }

        private void UpdateViewsPositions()
        {
            #if UNITY_EDITOR
            if (!Application.isPlaying) return;
            #endif
            
            GameField field = _state.GameField;
            int count = field.OnFieldObstacleCount;
            
            for (int i = 0; i < count; ++i)
            {
                ObstacleItem item = field.GetObstacleByIndex(i);

                IObstacleItemView view = _viewById[item.ID];
                view.SetX(item.Pos);
            }
        }

        private async void GameStartedHandler(bool started)
        {
            if (!started) return;

            await foreach (AsyncUnit _ in UniTaskAsyncEnumerable.EveryUpdate(PlayerLoopTiming.PreLateUpdate)
                               .TakeWhile(_ => _state.Started))
            {
                UpdateViewsPositions();
            }
        }

        private void ObstacleAddedHandler(ObstacleItem item)
        {
            IObstacleItemView view = _storage.GetView();
            
            _viewById.Add(item.ID, view);

            view.Id = item.ID;
            view.SetX(item.Pos);
            view.Visible = true;
        }

        private void ObstacleRemovedHandler(ObstacleItem item)
        {
            IObstacleItemView view = _viewById[item.ID];
            _viewById.Remove(item.ID);

            _storage.ReleaseView(view);
        }
    }
}
