using System;
using NickoJ.DinoRunner.Core.Config;
using UnityEngine;

namespace NickoJ.DinoRunner.Engine.Configs
{
    /// <summary>
    /// Parameters for bonuses.
    /// </summary>
    [Serializable]
    public sealed class BonusesConfig : IBonusesConfig
    {
        [field: SerializeField] public float AccelerationDuration { get; private set; } = 10f;
        [field: SerializeField] public int AccelerationModificator { get; private set; } = 100;

        [field: SerializeField] public float DeAccelerationDuration { get; private set; } = 10f;
        [field: SerializeField] public int DeAccelerationModificator { get; private set; } = -50;

        [field: SerializeField] public float FlyDuration { get; private set; } = 10f;

        [field: SerializeField] public float MinY { get; private set; } = 0.45f;
        [field: SerializeField] public float MaxY { get; private set; } = 0.95F;
        [field: SerializeField] public float Width { get; private set; } = 0.5f;
    }
}