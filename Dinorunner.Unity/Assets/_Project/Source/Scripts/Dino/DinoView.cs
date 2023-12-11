using System;
using NickoJ.DinoRunner.Scripts.Dino;
using UnityEngine;

namespace NickoJ.DinoRunner
{
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
