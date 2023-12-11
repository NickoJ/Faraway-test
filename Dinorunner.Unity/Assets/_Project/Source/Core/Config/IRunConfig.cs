namespace NickoJ.DinoRunner.Core.Config
{
    public interface IRunConfig
    {
        float MinSpeed { get; }
        float MaxSpeed { get; }
        float AccelerationTime { get; }
    }
}