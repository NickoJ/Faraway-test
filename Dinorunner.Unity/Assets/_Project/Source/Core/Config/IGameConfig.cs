namespace NickoJ.DinoRunner.Core.Config
{
    /// <summary>
    /// Container for all configs that has to be implemented on the engine side.
    /// </summary>
    public interface IGameConfig
    {
        IBonusesConfig Bonuses { get; }
        IRunConfig Run { get; }
        IPlayerConfig Player { get; }
        IObstacleConfig Obstacle { get; }
        IGravityConfig Gravity { get; }
        IGameFieldConfig GameField { get; }
        IBonusGeneratorConfig BonusGeneratorConfig { get; }
        IObstacleGeneratorConfig ObstacleGeneratorConfig { get; }
    }
}