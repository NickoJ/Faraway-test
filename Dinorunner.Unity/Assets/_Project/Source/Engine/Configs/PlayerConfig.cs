using System;
using NickoJ.DinoRunner.Core;
using NickoJ.DinoRunner.Core.Config;
using UnityEngine;

namespace NickoJ.DinoRunner.Engine.Configs
{
    [Serializable]
    internal sealed class PlayerConfig : IPlayerConfig
    {
        [field: SerializeField] public float JumpSpeed { get; private set; } = 3;
    }
}