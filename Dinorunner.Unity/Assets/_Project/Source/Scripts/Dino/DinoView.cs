using System;
using UnityEngine;

namespace NickoJ.DinoRunner.Scripts.Dino
{
    /// <summary>
    /// Dino view that updates visual of the character.
    /// </summary>
    public sealed class DinoView : MonoBehaviour, IDinoView
    {
        [SerializeField] private Transform root;
        [SerializeField] private DinoAnimatorWrapper animator;

        public event Action OnUpdate;

        private void LateUpdate()
        {
            OnUpdate?.Invoke();
        }

        public void UpdateView(float speed, float y, bool flying)
        {
            Vector3 pos = root.localPosition;
            pos.y = y;
            root.localPosition = pos;

            animator.UpdateAnimation(speed, y, flying);
        }
    }
}
