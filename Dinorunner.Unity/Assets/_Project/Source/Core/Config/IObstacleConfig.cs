namespace NickoJ.DinoRunner.Core.Config
{
    /// <summary>
    /// Parameters of obstacles that have to implemented on engine side.
    /// </summary>
    public interface IObstacleConfig
    {
        float MinY { get; }
        float MaxY { get; }
        float Width { get; }
    }
}