using System;
using System.Collections.Generic;
using NickoJ.DinoRunner.Core.GameSystems.Bonuses;

namespace NickoJ.DinoRunner.Core.Model.Bonuses
{
    /// <summary>
    /// Bonus factory and pool at the same time.
    /// </summary>
    public sealed class BonusFactory : IBonusFactory
    {
        private readonly Player _player;
        private readonly IBonusesConfig _config;

        private readonly Dictionary<Type, List<Bonus>> _bonusesPool = new();
        
        public BonusFactory(Player player)
        {
            _player = player;
        }

        public Bonus Build(BonusKind bonusKind)
        {
            switch (bonusKind)
            {
                case BonusKind.Acceleration:
                    return GetOrCreate<AccelerationBonus>(InitAccelerationBonus);
                case BonusKind.DeAcceleration:
                    return GetOrCreate<DeAccelerationBonus>(InitDeAccelerationBonus);
                case BonusKind.Fly:
                    return GetOrCreate<FlyBonus>(InitFlyBonus);
                default:
                    throw new ArgumentOutOfRangeException(nameof(bonusKind), bonusKind, null);
            }
        }

        private void InitAccelerationBonus(AccelerationBonus bonus)
        {
            bonus.Init(_player, _config.AccelerationDuration);
        }

        private void InitDeAccelerationBonus(DeAccelerationBonus bonus)
        {
            bonus.Init(_player, _config.DeAccelerationDuration);
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
    }
}