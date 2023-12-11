namespace NickoJ.DinoRunner.Core.Config
{
    /// <summary>
    /// Parameters of running that have to implemented on engine side.
    /// </summary>
    public interface IRunConfig
    {
        float MinSpeed { get; }
        float MaxSpeed { get; }
        float AccelerationTime { get; }
    }
}