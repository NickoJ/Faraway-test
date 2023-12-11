namespace NickoJ.DinoRunner.Core.Config
{
    /// <summary>
    /// Parameters of bonuses that has to implemented on engine side.
    /// </summary>
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