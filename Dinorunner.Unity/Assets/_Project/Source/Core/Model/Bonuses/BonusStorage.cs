using System;
using System.Collections.Generic;
using NickoJ.DinoRunner.Core.Config;
using NickoJ.DinoRunner.Core.GameSystems.Bonuses;

namespace NickoJ.DinoRunner.Core.Model.Bonuses
{
    /// <summary>
    /// Bonus factory and pool at the same time.
    /// </summary>
    public sealed class BonusStorage : IBonusStorage
    {
        private readonly Player _player;
        private readonly IBonusesConfig _config;

        private readonly Dictionary<Type, List<Bonus>> _bonusesPool = new();
        
        public BonusStorage(Player player, IBonusesConfig config)
        {
            _player = player;
            _config = config;
        }

        public Bonus Build(BonusKind bonusKind)
        {
            switch (bonusKind)
            {
                case BonusKind.Acceleration:
                    return GetOrCreate<ChangeSpeedBonus>(InitAccelerationBonus);
                case BonusKind.DeAcceleration:
                    return GetOrCreate<ChangeSpeedBonus>(InitDeAccelerationBonus);
                case BonusKind.Fly:
                    return GetOrCreate<FlyBonus>(InitFlyBonus);
                default:
                    throw new ArgumentOutOfRangeException(nameof(bonusKind), bonusKind, null);
            }
        }

        public void Release(Bonus bonus)
        {
            if (bonus == null) throw new ArgumentNullException(nameof(bonus));

            AddToPull(bonus as ChangeSpeedBonus);
            AddToPull(bonus as FlyBonus);
        }

        private void InitAccelerationBonus(ChangeSpeedBonus bonus)
        {
            bonus.Init(_player, _config.AccelerationModificator, _config.AccelerationDuration);
        }

        private void InitDeAccelerationBonus(ChangeSpeedBonus bonus)
        {
            bonus.Init(_player, _config.DeAccelerationModificator, _config.DeAccelerationDuration);
        }

        private void InitFlyBonus(FlyBonus bonus)
        {
            bonus.Init(_player, _config.FlyDuration);
        }

        private T GetOrCreate<T>(Action<T> initiator) where T : Bonus, new()
        {
            if (!_bonusesPool.TryGetValue(typeof(T), out List<Bonus> inactiveBonuses))
            {
                inactiveBonuses = new List<Bonus>();
                _bonusesPool[typeof(T)] = inactiveBonuses;
            }

            T bonus;
            
            if (inactiveBonuses.Count == 0)
            {
                bonus = new T();
            }
            else
            {
                bonus = (T)inactiveBonuses[^1];
                inactiveBonuses.RemoveAt(inactiveBonuses.Count - 1);
            }

            initiator(bonus);
            
            return bonus;
        }

        private void AddToPull<T>(T bonus) where T : Bonus
        {
            if (bonus != null && _bonusesPool.TryGetValue(typeof(T), out List<Bonus> bonuses))
            {
                bonuses.Add(bonus);
            }
        }
    }
}