using NickoJ.DinoRunner.Core.Model.Bonuses;
using UnityEngine;

namespace NickoJ.DinoRunner.Scripts.Bonuses
{
    /// <summary>
    /// View of the bonus
    /// </summary>
    public sealed class BonusItemView : MonoBehaviour, IBonusItemView
    {
        [SerializeField] private BonusKind kind;

        /// <summary>
        /// Id of the bonus
        /// </summary>
        public uint Id { get; set; }
        
        /// <summary>
        /// Kind of the bonus
        /// </summary>
        public BonusKind Kind => kind;

        /// <summary>
        /// Shows whether bonus is visible or not.
        /// </summary>
        public bool Visible
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
        }

        /// <summary>
        /// Move bonus according to sent x value.
        /// </summary>
        /// <param name="x"></param>
        public void SetX(float x)
        {
            Transform t = transform;

            Vector3 pos = t.position;
            pos.x = x;
            t.position = pos;
        }
    }
}