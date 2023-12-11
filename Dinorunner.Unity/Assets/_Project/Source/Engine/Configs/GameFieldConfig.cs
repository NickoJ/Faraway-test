using System;
using NickoJ.DinoRunner.Core.Config;
using UnityEngine;

namespace NickoJ.DinoRunner.Engine.Configs
{
    [Serializable]
    internal sealed class GameFieldConfig : IGameFieldConfig
    {
        [field: SerializeField] public int MaxBonusItemsCount { get; private set; } = 5;
    }
}