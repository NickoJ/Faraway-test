namespace NickoJ.DinoRunner.Core.Config
{
    /// <summary>
    /// Parameters of game field that has to implemented on engine side.
    /// </summary>
    public interface IGameFieldConfig
    {
        int MaxBonusItemsCount { get; }
        int MaxObstacleItemsCount { get; }
    }
}