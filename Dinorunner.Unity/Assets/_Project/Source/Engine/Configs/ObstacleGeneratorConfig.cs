using System;
using NickoJ.DinoRunner.Core.Config;
using UnityEngine;

namespace NickoJ.DinoRunner.Engine.Configs
{
    /// <summary>
    /// Parameters of obstacle generator.
    /// </summary>
    [Serializable]
    internal sealed class ObstacleGeneratorConfig : IObstacleGeneratorConfig
    {
        [field: SerializeField] public float SpawnIntervalMin { get; private set; } = 1f;
        [field: SerializeField] public float SpawnIntervalMax { get; private set; } = 20f;

        [field: SerializeField] public float SpawnDistance { get; private set; } = 30f;
    }
}