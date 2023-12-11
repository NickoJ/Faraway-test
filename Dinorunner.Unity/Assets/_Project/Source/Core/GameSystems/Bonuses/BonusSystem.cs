using System.Collections.Generic;
using NickoJ.DinoRunner.Core.Model.Bonuses;

namespace NickoJ.DinoRunner.Core.GameSystems.Bonuses
{
    internal sealed class BonusSystem : GameSystem, IUpdateGameSystem, IBonusSystem
    {
        private readonly IBonusStorage _bonusStorage;
        private readonly List<Bonus> _bonuses = new ();

        public BonusSystem(IBonusStorage bonusStorage) : base(false)
        {
            _bonusStorage = bonusStorage;
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
    }
}