using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using NickoJ.DinoRunner.Core.Model;
using UnityEngine;

namespace NickoJ.DinoRunner.Scripts.Bonuses
{
    /// <summary>
    /// Responds for appearing/hiding/moving of bonuses in the visual part of the game.
    /// </summary>
    public sealed class BonusesController
    {
        private readonly IGameState _state;
        private readonly IBonusViewsStorage _storage;

        private readonly Dictionary<uint, IBonusItemView> _viewById = new();

        public BonusesController(IGameState state, IBonusViewsStorage storage)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));

            _state.GameField.OnBonusAdded += BonusAddedHandler;
            _state.GameField.OnBonusRemoved += BonusRemovedHandler;

            _state.OnGameStarted += GameStartedHandler;
        }

        private void UpdateViewsPositions()
        {
            #if UNITY_EDITOR
            if (!Application.isPlaying) return;
            #endif
            
            GameField field = _state.GameField;
            int count = field.OnFieldBonusCount;
            
            for (int i = 0; i < count; ++i)
            {
                BonusItem item = field.GetBonusByIndex(i);

                IBonusItemView view = _viewById[item.ID];
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

        private void BonusAddedHandler(BonusItem item)
        {
            IBonusItemView view = _storage.GetView(item.Kind);
            
            _viewById.Add(item.ID, view);

            view.Id = item.ID;
            view.SetX(item.Pos);
            view.Visible = true;
        }

        private void BonusRemovedHandler(BonusItem item)
        {
            IBonusItemView view = _viewById[item.ID];
            _viewById.Remove(item.ID);

            _storage.ReleaseView(view);
        }
    }
}
