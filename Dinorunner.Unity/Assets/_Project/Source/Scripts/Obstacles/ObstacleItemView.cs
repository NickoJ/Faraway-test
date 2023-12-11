using UnityEngine;

namespace NickoJ.DinoRunner.Scripts.Obstacles
{
    /// <summary>
    /// Obstacle view that shows/hides itself and moves along x axis.
    /// </summary>
    public sealed class ObstacleItemView : MonoBehaviour, IObstacleItemView
    {
        public uint Id { get; set; }
        
        public bool Visible
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
        }

        public void SetX(float x)
        {
            Transform t = transform;

            Vector3 pos = t.position;
            pos.x = x;
            t.position = pos;
        }
    }
}