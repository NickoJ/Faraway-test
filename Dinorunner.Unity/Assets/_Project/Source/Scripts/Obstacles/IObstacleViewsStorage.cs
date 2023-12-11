namespace NickoJ.DinoRunner.Scripts.Obstacles
{
    /// <summary>
    /// ObstacleViewsStorages' API.
    /// </summary>
    public interface IObstacleViewsStorage
    {
        IObstacleItemView GetView();
        void ReleaseView(IObstacleItemView view);
    }
}