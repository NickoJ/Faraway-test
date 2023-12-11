namespace NickoJ.DinoRunner.Core.Model
{
    /// <summary>
    /// Obstacle item.
    /// </summary>
    public struct ObstacleItem
    {
        public readonly uint ID;
        public float Pos;

        public ObstacleItem(uint id, float pos)
        {
            ID = id;
            Pos = pos;
        }
    }
}