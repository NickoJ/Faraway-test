using System;
using NickoJ.DinoRunner.Core.Config;
using UnityEngine;

namespace NickoJ.DinoRunner.Engine.Configs
{
    [CreateAssetMenu]
    public sealed class GameConfig : ScriptableObject, IGameConfig
    {
        [SerializeField] private BonusesConfig bonuses;
        [SerializeField] private RunConfig run;
        [SerializeField] private PlayerConfig player;
        [SerializeField] private GravityConfig gravity;
        [SerializeField] private GameFieldConfig gameField;
        [SerializeField] private BonusGeneratorConfig bonusGeneratorConfig;
        [SerializeField] private ObstacleGeneratorConfig obstacleGeneratorConfig;

        IBonusesConfig IGameConfig.Bonuses => bonuses;
        IRunConfig IGameConfig.Run => run;
        IPlayerConfig IGameConfig.Player => player;
        IGravityConfig IGameConfig.Gravity => gravity;
        IGameFieldConfig IGameConfig.GameField => gameField;
        IBonusGeneratorConfig IGameConfig.BonusGeneratorConfig => bonusGeneratorConfig;
        IObstacleGeneratorConfig IGameConfig.ObstacleGeneratorConfig => obstacleGeneratorConfig;
    }

    [Serializable]
    internal sealed class ObstacleGeneratorConfig : IObstacleGeneratorConfig
    {
        [field: SerializeField] public float SpawnIntervalMin { get; private set; } = 1f;
        [field: SerializeField] public float SpawnIntervalMax { get; private set; } = 20f;

        [field: SerializeField] public float SpawnDistance { get; private set; } = 30f;
    }
}