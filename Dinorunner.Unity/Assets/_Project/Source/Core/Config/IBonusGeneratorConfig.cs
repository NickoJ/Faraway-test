using System.Collections.Generic;
using NickoJ.DinoRunner.Core.Model.Bonuses;

namespace NickoJ.DinoRunner.Core.Config
{
    /// <summary>
    /// Parameters of bonus generator that has to implemented on engine side.
    /// </summary>
    public interface IBonusGeneratorConfig
    {
        public float SpawnIntervalMin { get; }
        public float SpawnIntervalMax { get; }
        
        public float SpawnDistance { get; }

        public IReadOnlyDictionary<BonusKind, float> SpawnChances { get; }
    }
}