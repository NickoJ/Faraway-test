namespace NickoJ.DinoRunner.Core.Config
{
    public interface IBonusesConfig
    {
        float AccelerationDuration { get; }
        float DeAccelerationDuration { get; }
        float FlyDuration { get; }

        float MinY { get; }
        float MaxY { get; }

        float Width { get; }
    }
}