using System;
using System.Collections.Generic;
using NickoJ.DinoRunner.Core.Config;
using NickoJ.DinoRunner.Core.Model.Bonuses;
using UnityEngine;

namespace NickoJ.DinoRunner.Engine.Configs
{
    /// <summary>
    /// Parameters for bonus generator.
    /// </summary>
    [Serializable]
    internal sealed class BonusGeneratorConfig : IBonusGeneratorConfig
    {
        [field: SerializeField] public float SpawnIntervalMin { get; private set; } = 1;
        [field: SerializeField] public float SpawnIntervalMax { get; private set; } = 10;
        [field: SerializeField] public float SpawnDistance { get; private set; } = 30;

        [field: SerializeField]
        public SpawnChance[] SpawnChances { get; private set; } = 
        {
            new(BonusKind.Acceleration, 2),
            new(BonusKind.DeAcceleration, 4),
            new(BonusKind.Fly, 1),
        };

        private Dictionary<BonusKind, float> _spawnChances;
        
        IReadOnlyDictionary<BonusKind, float> IBonusGeneratorConfig.SpawnChances
        {
            get
            {
                if (_spawnChances == null)
                {
                    _spawnChances = new Dictionary<BonusKind, float>();

                    foreach (SpawnChance spawnChance in SpawnChances)
                    {
                        _spawnChances.Add(spawnChance.kind, spawnChance.chance);
                    }                    
                }

                return _spawnChances;
            }
        }

        [Serializable]
        internal struct SpawnChance
        {
            public BonusKind kind;
            public float chance;

            public SpawnChance(BonusKind kind, float chance)
            {
                this.kind = kind;
                this.chance = chance;                    
            }
        }
    }
}