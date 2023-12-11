using System;
using NickoJ.DinoRunner.Core.Model.Bonuses;
using UnityEngine;

namespace NickoJ.DinoRunner.Scripts.Bonuses
{
    public sealed class BonusItemView : MonoBehaviour, IBonusItemView
    {
        [SerializeField] private BonusKind kind;

        public uint Id { get; set; }
        
        public BonusKind Kind => kind;

        public bool Visible
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
        }

        public event Action<IBonusItemView> OnDestroyed;

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
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