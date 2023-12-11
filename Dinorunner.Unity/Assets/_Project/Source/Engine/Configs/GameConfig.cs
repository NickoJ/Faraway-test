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
        [SerializeField] private ObstacleConfig obstacle;

        IBonusesConfig IGameConfig.Bonuses => bonuses;
        IRunConfig IGameConfig.Run => run;
        IPlayerConfig IGameConfig.Player => player;
        IObstacleConfig IGameConfig.Obstacle => obstacle;
        IGravityConfig IGameConfig.Gravity => gravity;
        IGameFieldConfig IGameConfig.GameField => gameField;
        IBonusGeneratorConfig IGameConfig.BonusGeneratorConfig => bonusGeneratorConfig;
        IObstacleGeneratorConfig IGameConfig.ObstacleGeneratorConfig => obstacleGeneratorConfig;
    }

    [Serializable]
    internal sealed class ObstacleConfig : IObstacleConfig
    {
        [field: SerializeField] public float MinY { get; private set; } = 0f;
        [field: SerializeField] public float MaxY { get; private set; } = 0.5f;
        [field: SerializeField] public float Width { get; private set; } = 0.7f;
    }
}