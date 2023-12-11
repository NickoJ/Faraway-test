using System;
using NickoJ.DinoRunner.Core.Config;
using NickoJ.DinoRunner.Core.Model.Bonuses;

namespace NickoJ.DinoRunner.Core.Model
{
    public sealed class GameField
    {
        private readonly IGameFieldConfig _config;

        private readonly BonusItem[] _bonusItems;

        private int _onFieldBonusCount = 0;
        private uint _nextId = 1;

        public int OnFieldBonusCount => _onFieldBonusCount;
        
        public event Action<BonusItem> OnBonusAdded;
        public event Action<BonusItem> OnBonusRemoved;
        
        internal GameField(IGameFieldConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            
            _bonusItems = new BonusItem[config.MaxBonusItemsCount];
        }

        public BonusItem GetBonusByIndex(int index) => GetRefBonusByIndex(index);

        internal ref BonusItem GetRefBonusByIndex(int index)
        {
            return ref _bonusItems[index];
        }

        internal bool CanAddBonus() => _onFieldBonusCount < _bonusItems.Length;

        internal void AddBonus(BonusKind bonus, float pos)
        {
            uint id = _nextId;

            unchecked { _nextId++; }

            if (_nextId == 0) _nextId = 1;

            AddBonus(new BonusItem(id, bonus, pos));
        }

        internal void RemoveBonusByIndex(int index)
        {
            BonusItem bonus = _bonusItems[index];

            _bonusItems[index] = default;
            
            _onFieldBonusCount -= 1;
            
            (_bonusItems[index], _bonusItems[_onFieldBonusCount]) = (_bonusItems[_onFieldBonusCount], _bonusItems[index]);
            
            OnBonusRemoved?.Invoke(bonus);
        }

        private void AddBonus(BonusItem bonus)
        {
            if (!CanAddBonus()) return;

            _bonusItems[_onFieldBonusCount] = bonus;
            _onFieldBonusCount += 1;

            OnBonusAdded?.Invoke(bonus);
        }
    }
}