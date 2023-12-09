using System.Collections.Generic;
using NickoJ.DinoRunner.Core.Model.Bonuses;

namespace NickoJ.DinoRunner.Core.GameSystems.Bonuses
{
    public sealed class BonusSystem : GameSystem, IUpdateGameSystem
    {
        private readonly IBonusFactory _bonusFactory;
        private readonly List<Bonus> _bonuses = new ();

        public BonusSystem(IBonusFactory bonusFactory)
        {
            _bonusFactory = bonusFactory;
        }
        
        public void AddBonus(BonusKind bonusKind)
        {
            Bonus bonus = _bonusFactory.Build(bonusKind);
            bonus.Apply();

            _bonuses.Add(bonus);
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
                    _bonuses[i].Revoke();
                    (_bonuses[i], _bonuses[minDeleteIndex]) = (_bonuses[minDeleteIndex], _bonuses[i]);
                }
            }

            if (minDeleteIndex < _bonuses.Count)
            {
                _bonuses.RemoveRange(minDeleteIndex, _bonuses.Count - minDeleteIndex);
            }
        }
    }
}