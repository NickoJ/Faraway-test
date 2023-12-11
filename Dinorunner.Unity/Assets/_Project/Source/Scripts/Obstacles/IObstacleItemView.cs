namespace NickoJ.DinoRunner.Scripts.Obstacles
{
    public interface IObstacleItemView
    {
        uint Id { get; set; }
        bool Visible { get; set; }

        void SetX(float x);
    }
}