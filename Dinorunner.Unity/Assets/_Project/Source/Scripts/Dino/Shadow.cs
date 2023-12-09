using UnityEngine;

namespace NickoJ.DinoRunner.Scripts.Dino
{
    public sealed class Shadow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private AnimationCurve downscaleCurve = AnimationCurve.Linear(0.1f, 1, 3, 0.1f);

        private void LateUpdate()
        {
            UnityEngine.Debug.Log("MEOW");
            float dist = Vector2.Distance(transform.position, target.position);
            float scale = downscaleCurve.Evaluate(dist);
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
