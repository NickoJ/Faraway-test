using UnityEngine;

namespace NickoJ.DinoRunner.Scripts.Background
{
    /// <summary>
    /// Responds for a specific layer of the background.
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class BackgroundLayer : MonoBehaviour
    {
        [SerializeField] private float parallaxFactor = 1f;
        [SerializeField] private float repeatFactor = 0.5f;
        
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        /// <summary>
        /// Move the layer according to moved distance.
        /// </summary>
        /// <param name="movedDistance"></param>
        public void Move(float movedDistance)
        {
            Vector3 pos = transform.position;
            pos.x -= parallaxFactor * movedDistance;

            float repeatValue = _spriteRenderer.bounds.size.x * repeatFactor;
            
            while (pos.x < -repeatValue)
            {
                pos.x += repeatValue;
            }

            transform.position = pos;
        }
    }
}