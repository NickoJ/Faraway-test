using System;
using NickoJ.DinoRunner.Core.Config;
using NickoJ.DinoRunner.Core.Model.Bonuses;

namespace NickoJ.DinoRunner.Core.Model
{
    public sealed class GameField
    {
        private readonly IGameFieldConfig _config;

        private readonly BonusItem[] _bonusItems;
        private readonly ObstacleItem[] _obstacleItems;

        private int _onFieldBonusCount = 0;
        private int _onFieldObstacleCount = 0;

        private uint _nextBonusId = 1;
        private uint _nextObstacleId = 1;

        public int OnFieldBonusCount => _onFieldBonusCount;

        public int OnFieldObstacleCount => _onFieldObstacleCount;

        public event Action<BonusItem> OnBonusAdded;
        public event Action<BonusItem> OnBonusRemoved;

        public event Action<ObstacleItem> OnObstacleAdded;
        public event Action<ObstacleItem> OnObstacleRemoved;
        
        internal GameField(IGameFieldConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            
            _bonusItems = new BonusItem[config.MaxBonusItemsCount];
            _obstacleItems = new ObstacleItem[config.MaxObstacleItemsCount];
        }

        public BonusItem GetBonusByIndex(int index) => _bonusItems[index];

        public ObstacleItem GetObstacleByIndex(int index) => _obstacleItems[index];

        internal ref BonusItem GetRefBonusByIndex(int index)
        {
            return ref _bonusItems[index];
        }

        internal ref ObstacleItem GetRefObstacleByIndex(int index)
        {
            return ref _obstacleItems[index]; 
        }

        internal bool CanAddBonus() => _onFieldBonusCount < _bonusItems.Length;

        internal bool CanAddObstacle() => _onFieldObstacleCount < _obstacleItems.Length;

        internal void AddBonus(BonusKind bonus, float pos)
        {
            if (!CanAddBonus()) return;
            
            uint id = _nextBonusId;

            unchecked { _nextBonusId++; }

            if (_nextBonusId == 0) _nextBonusId = 1;

            AddBonus(new BonusItem(id, bonus, pos));
        }

        internal void AddObstacle(float pos)
        {
            if (!CanAddObstacle()) return;

            uint id = _nextObstacleId;
            
            unchecked { _nextObstacleId++; }
            
            if (_nextObstacleId == 0) _nextObstacleId = 1;
            
            AddObstacle(new ObstacleItem(id, pos));
        }

        internal void RemoveBonusByIndex(int index)
        {
            BonusItem bonus = _bonusItems[index];

            _bonusItems[index] = default;
            
            _onFieldBonusCount -= 1;
            
            (_bonusItems[index], _bonusItems[_onFieldBonusCount]) = (_bonusItems[_onFieldBonusCount], _bonusItems[index]);
            
            OnBonusRemoved?.Invoke(bonus);
        }

        internal void RemoveObstacleByIndex(int index)
        {
            ObstacleItem obstacle = _obstacleItems[index];

            _obstacleItems[index] = default;
            
            _onFieldObstacleCount -= 1;
            
            (_obstacleItems[index], _obstacleItems[_onFieldObstacleCount]) = (_obstacleItems[_onFieldObstacleCount], _obstacleItems[index]);
            
            OnObstacleRemoved?.Invoke(obstacle);
        }

        private void AddBonus(BonusItem bonus)
        {
            if (!CanAddBonus()) return;

            _bonusItems[_onFieldBonusCount] = bonus;
            _onFieldBonusCount += 1;

            OnBonusAdded?.Invoke(bonus);
        }

        private void AddObstacle(ObstacleItem obstacle)
        {
            if (!CanAddObstacle()) return;
            
            _obstacleItems[_onFieldObstacleCount] = obstacle;
            _onFieldObstacleCount += 1;

            OnObstacleAdded?.Invoke(obstacle);
        }
    }
}