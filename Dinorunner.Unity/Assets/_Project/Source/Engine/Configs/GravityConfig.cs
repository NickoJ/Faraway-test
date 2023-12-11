using System;
using NickoJ.DinoRunner.Core.Config;
using UnityEngine;

namespace NickoJ.DinoRunner.Engine.Configs
{
    [Serializable]
    internal sealed class GravityConfig : IGravityConfig
    {
        [field: SerializeField] public float Gravity { get; private set; } = -5f;
    }
}