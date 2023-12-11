namespace NickoJ.DinoRunner.Core.Config
{
    public interface IBonusesConfig
    {
        float AccelerationDuration { get; }
        int AccelerationModificator { get; }

        float DeAccelerationDuration { get; }
        int DeAccelerationModificator { get; }

        float FlyDuration { get; }

        float MinY { get; }
        float MaxY { get; }

        float Width { get; }
    }
}