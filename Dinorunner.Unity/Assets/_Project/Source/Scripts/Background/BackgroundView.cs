using UnityEngine;

namespace NickoJ.DinoRunner.Scripts.Background
{
    /// <summary>
    /// BackgroundView that's responsible for all background layers.
    /// </summary>
    public sealed class BackgroundView : MonoBehaviour
    {
        private const float MaxAwakeOffsetDistance = 300f; 
        
        [SerializeField] private BackgroundLayer[] layers;

        public float MoveSpeed { get; set; } = 0f;

        private void Start()
        {
            float moveDistance = Random.Range(0, MaxAwakeOffsetDistance);
            MoveLayers(moveDistance);
        }
        
        private void LateUpdate()
        {
            float moveDistance = MoveSpeed * Time.deltaTime;

            MoveLayers(moveDistance);
        }

        private void MoveLayers(float moveDistance)
        {
            foreach (BackgroundLayer layer in layers)
            {
                layer.Move(moveDistance);
            }
        }

#if UNITY_EDITOR

        private void Reset()
        {
            layers = transform.GetComponentsInChildren<BackgroundLayer>();
        }

#endif
    }
}
