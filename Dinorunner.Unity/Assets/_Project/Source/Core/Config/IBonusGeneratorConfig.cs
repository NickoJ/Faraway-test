using System.Collections.Generic;
using NickoJ.DinoRunner.Core.Model.Bonuses;

namespace NickoJ.DinoRunner.Core.Config
{
    public interface IBonusGeneratorConfig
    {
        public float SpawnIntervalMin { get; }
        public float SpawnIntervalMax { get; }
        
        public float SpawnDistance { get; }

        public IReadOnlyDictionary<BonusKind, float> SpawnChances { get; }
    }
}