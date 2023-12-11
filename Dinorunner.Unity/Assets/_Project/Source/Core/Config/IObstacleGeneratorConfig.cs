namespace NickoJ.DinoRunner.Core.Config
{
    /// <summary>
    /// Parameters of obstacle generator that have to implemented on engine side.
    /// </summary>
    public interface IObstacleGeneratorConfig
    {
        float SpawnDistance { get; }

        float SpawnIntervalMin { get; }
        float SpawnIntervalMax { get; }
    }
}