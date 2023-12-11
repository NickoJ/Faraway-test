namespace NickoJ.DinoRunner.Core.Config
{
    public interface IPlayerConfig
    {
        float X { get; }
        float Width { get; }
        float Height { get; }

        float JumpSpeed { get; }
        float FlyDelay { get; }
        float FlyUpSpeed { get; }
        float FlyY { get; }
    }
}