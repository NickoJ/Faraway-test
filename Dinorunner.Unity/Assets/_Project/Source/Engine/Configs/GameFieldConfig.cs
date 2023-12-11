using System;
using NickoJ.DinoRunner.Core.Config;
using UnityEngine;

namespace NickoJ.DinoRunner.Engine.Configs
{
    /// <summary>
    /// Parameters of game field.
    /// </summary>
    [Serializable]
    internal sealed class GameFieldConfig : IGameFieldConfig
    {
        [field: SerializeField] public int MaxBonusItemsCount { get; private set; } = 5;

        [field: SerializeField] public int MaxObstacleItemsCount { get; private set; } = 3;
    }
}