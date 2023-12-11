namespace NickoJ.DinoRunner.Core.Config
{
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