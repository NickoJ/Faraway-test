using UnityEngine;

namespace NickoJ.DinoRunner.Scripts.Dino
{
    /// <summary>
    /// Change shadow sprite's scale depending on distance to target.
    /// </summary>
    public sealed class Shadow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private AnimationCurve downscaleCurve = AnimationCurve.Linear(0.1f, 1, 3, 0.1f);

        private void LateUpdate()
        {
            float dist = Vector2.Distance(transform.position, target.position);
            float scale = downscaleCurve.Evaluate(dist);
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
