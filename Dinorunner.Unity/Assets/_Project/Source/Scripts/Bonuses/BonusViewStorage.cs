using System.Collections.Generic;
using NickoJ.DinoRunner.Core.Model.Bonuses;
using UnityEngine;
using UnityEngine.Pool;

namespace NickoJ.DinoRunner.Scripts.Bonuses
{
    /// <summary>
    /// Storage of object pool for bonus item views.
    /// </summary>
    public sealed class BonusViewStorage : IBonusViewsStorage
    {
        private readonly Transform _root;
        private readonly Dictionary<BonusKind, IObjectPool<BonusItemView>> _pools = new();
        
        public BonusViewStorage(Transform root, IEnumerable<BonusItemView> viewPrefabs)
        {
            _root = root;

            foreach (BonusItemView prefab in viewPrefabs)
            {
                var pool = new ObjectPool<BonusItemView>
                (
                    () => CreateView(prefab),
                    actionOnDestroy: DestroyView
                );

                _pools[prefab.Kind] = pool;
            }
        }

        /// <summary>
        /// Return bonus item view with specified BonusKind.
        /// </summary>
        /// <param name="itemKind">Kind of the required view.</param>
        /// <returns></returns>
        public IBonusItemView GetView(BonusKind itemKind)
        {
            return _pools[itemKind].Get();
        }

        /// <summary>
        /// Releases the view.
        /// </summary>
        /// <param name="view">View that has to be released.</param>
        public void ReleaseView(IBonusItemView view)
        {
            if (view is BonusItemView castedView)
            {
                castedView.Visible = false;
                _pools[castedView.Kind].Release(castedView);
            }
        }

        private BonusItemView CreateView(BonusItemView prefab)
        {
            BonusItemView view = Object.Instantiate(prefab, _root, true);
            view.Visible = false;

            return view;
        }

        private void DestroyView(BonusItemView view)
        {
            Object.Destroy(view.gameObject);
        }
    }
}