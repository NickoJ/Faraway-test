using System;
using NickoJ.DinoRunner.Core.Config;
using UnityEngine;

namespace NickoJ.DinoRunner.Engine.Configs
{
    [Serializable]
    internal sealed class PlayerConfig : IPlayerConfig
    {
        [field: SerializeField] public float X { get; private set; } = 2;
        [field: SerializeField] public float Width { get; private set; } = 0.8f;
        [field: SerializeField] public float Height { get; private set; } = 0.9f;

        [field: SerializeField] public float JumpSpeed { get; private set; } = 3;
    }
}