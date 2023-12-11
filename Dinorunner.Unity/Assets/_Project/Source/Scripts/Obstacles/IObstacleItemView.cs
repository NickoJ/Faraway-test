namespace NickoJ.DinoRunner.Scripts.Obstacles
{
    /// <summary>
    /// ObstacleItemViews' API
    /// </summary>
    public interface IObstacleItemView
    {
        uint Id { get; set; }
        bool Visible { get; set; }

        void SetX(float x);
    }
}