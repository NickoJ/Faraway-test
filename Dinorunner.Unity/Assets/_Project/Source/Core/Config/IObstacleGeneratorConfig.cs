namespace NickoJ.DinoRunner.Core.Config
{
    public interface IObstacleGeneratorConfig
    {
        float SpawnDistance { get; }

        float SpawnIntervalMin { get; }
        float SpawnIntervalMax { get; }
    }
}