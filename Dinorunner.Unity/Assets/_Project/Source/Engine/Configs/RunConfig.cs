using System;
using NickoJ.DinoRunner.Core.Config;
using NickoJ.DinoRunner.Core.GameSystems.PlayerMovement;
using UnityEngine;

namespace NickoJ.DinoRunner.Engine.Configs
{
    [Serializable]
    internal sealed class RunConfig : IRunConfig
    {
        [field: SerializeField] public float MinSpeed { get; private set; } = 1;
        [field: SerializeField] public float MaxSpeed { get; private set; } = 15;
        [field: SerializeField] public float AccelerationTime { get; private set; } = 30;
    }
}