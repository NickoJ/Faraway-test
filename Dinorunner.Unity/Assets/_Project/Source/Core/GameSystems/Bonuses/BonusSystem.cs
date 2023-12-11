using System;
using System.Collections.Generic;
using NickoJ.DinoRunner.Core.Model;
using NickoJ.DinoRunner.Core.Model.Bonuses;

namespace NickoJ.DinoRunner.Core.GameSystems.Bonuses
{
    internal sealed class BonusSystem : GameSystem, IUpdateGameSystem, IFinishGameSystem, IBonusSystem
    {
        private readonly IGameState _state;
        private readonly IBonusStorage _bonusStorage;
        private readonly List<Bonus> _bonuses = new ();

        public BonusSystem(IGameState state, IBonusStorage bonusStorage) : base(false)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
            _bonusStorage = bonusStorage ?? throw new ArgumentNullException(nameof(bonusStorage));

            _state.OnGameStarted += GameStartedHandler;
        }
        
        public void AddBonus(BonusKind bonusKind)
        {
            Bonus bonus = _bonusStorage.Build(bonusKind);
            bonus.Apply();

            _bonuses.Add(bonus);

            if (_bonuses.Count == 1)
            {
                Start();
            }
        }
        
        void IUpdateGameSystem.Update(float dt)
        {
            int minDeleteIndex = _bonuses.Count;

            for (int i = _bonuses.Count - 1; i >= 0; i--)
            {
                _bonuses[i].Update(dt);

                if (!_bonuses[i].IsActive)
                {
                    minDeleteIndex -= 1;
                    (_bonuses[i], _bonuses[minDeleteIndex]) = (_bonuses[minDeleteIndex], _bonuses[i]);
                    
                    _bonuses[minDeleteIndex].Revoke();
                    _bonusStorage.Release(_bonuses[minDeleteIndex]);
                }
            }

            if (minDeleteIndex < _bonuses.Count)
            {
                _bonuses.RemoveRange(minDeleteIndex, _bonuses.Count - minDeleteIndex);

                if (_bonuses.Count == 0)
                {
                    Stop();
                }
            }
        }

        void IFinishGameSystem.Finish()
        {
            for (int i = _bonuses.Count - 1; i >= 0; i--)
            {
                _bonuses[i].Revoke();
                _bonusStorage.Release(_bonuses[i]);
            }
            
            _bonuses.Clear();
        }

        private void GameStartedHandler(bool started)
        {
            if (!started)
            {
                Stop();
            }
        }
    }
}