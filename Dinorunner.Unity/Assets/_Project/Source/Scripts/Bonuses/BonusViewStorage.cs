using System.Collections.Generic;
using NickoJ.DinoRunner.Core.Model.Bonuses;
using UnityEngine;
using UnityEngine.Pool;

namespace NickoJ.DinoRunner.Scripts.Bonuses
{
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

        public IBonusItemView GetView(BonusKind itemKind)
        {
            return _pools[itemKind].Get();
        }

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