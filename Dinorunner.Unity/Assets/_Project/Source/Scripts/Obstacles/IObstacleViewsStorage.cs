namespace NickoJ.DinoRunner.Scripts.Obstacles
{
    public interface IObstacleViewsStorage
    {
        IObstacleItemView GetView();
        void ReleaseView(IObstacleItemView view);
    }
}