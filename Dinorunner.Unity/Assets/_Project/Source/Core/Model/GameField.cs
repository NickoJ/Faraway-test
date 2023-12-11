using System;
using NickoJ.DinoRunner.Core.Config;
using NickoJ.DinoRunner.Core.Model.Bonuses;

namespace NickoJ.DinoRunner.Core.Model
{
    /// <summary>
    /// Game field that contains all active bonuses and obstacles.
    /// </summary>
    public sealed class GameField
    {
        private readonly IGameFieldConfig _config;

        private readonly BonusItem[] _bonusItems;
        private readonly ObstacleItem[] _obstacleItems;

        private int _onFieldBonusCount = 0;
        private int _onFieldObstacleCount = 0;

        private uint _nextBonusId = 1;
        private uint _nextObstacleId = 1;

        /// <summary>
        /// Active bonuses count
        /// </summary>
        public int OnFieldBonusCount => _onFieldBonusCount;

        /// <summary>
        /// Active obstacles count.
        /// </summary>
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

        /// <summary>
        /// Return bonus by index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public BonusItem GetBonusByIndex(int index) => _bonusItems[index];

        /// <summary>
        /// Return obstacle by index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ObstacleItem GetObstacleByIndex(int index) => _obstacleItems[index];

        /// <summary>
        /// Return reference to BonusItem struct.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        internal ref BonusItem GetRefBonusByIndex(int index)
        {
            return ref _bonusItems[index];
        }

        /// <summary>
        /// Return reference to ObstacleItem struct.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        internal ref ObstacleItem GetRefObstacleByIndex(int index)
        {
            return ref _obstacleItems[index]; 
        }

        /// <summary>
        /// Check if can add bonus.
        /// </summary>
        /// <returns></returns>
        internal bool CanAddBonus() => _onFieldBonusCount < _bonusItems.Length;

        /// <summary>
        /// Check if can add obstacle.
        /// </summary>
        /// <returns></returns>
        internal bool CanAddObstacle() => _onFieldObstacleCount < _obstacleItems.Length;

        /// <summary>
        /// Add bonus with specified kind and position.
        /// </summary>
        /// <param name="bonus"></param>
        /// <param name="pos"></param>
        internal void AddBonus(BonusKind bonus, float pos)
        {
            if (!CanAddBonus()) return;
            
            uint id = _nextBonusId;

            unchecked { _nextBonusId++; }

            if (_nextBonusId == 0) _nextBonusId = 1;

            AddBonus(new BonusItem(id, bonus, pos));
        }

        /// <summary>
        /// Add obstacle with specified position.
        /// </summary>
        /// <param name="pos"></param>
        internal void AddObstacle(float pos)
        {
            if (!CanAddObstacle()) return;

            uint id = _nextObstacleId;
            
            unchecked { _nextObstacleId++; }
            
            if (_nextObstacleId == 0) _nextObstacleId = 1;
            
            AddObstacle(new ObstacleItem(id, pos));
        }

        /// <summary>
        /// Remove bonus by index.
        /// </summary>
        /// <param name="index"></param>
        internal void RemoveBonusByIndex(int index)
        {
            BonusItem bonus = _bonusItems[index];

            _bonusItems[index] = default;
            
            _onFieldBonusCount -= 1;
            
            (_bonusItems[index], _bonusItems[_onFieldBonusCount]) = (_bonusItems[_onFieldBonusCount], _bonusItems[index]);
            
            OnBonusRemoved?.Invoke(bonus);
        }

        /// <summary>
        /// Remove obstacle by index.
        /// </summary>
        /// <param name="index"></param>
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