using UnityEngine;
using UnityEngine.Pool;

namespace NickoJ.DinoRunner.Scripts.Obstacles
{
    /// <summary>
    /// Storage for obstacle views. Using object pool inside.
    /// </summary>
    public sealed class ObstacleViewStorage : IObstacleViewsStorage
    {
        private readonly Transform _root;
        private readonly ObstacleItemView _viewPrefab;
        private readonly IObjectPool<ObstacleItemView> _pool;

        public ObstacleViewStorage(Transform root, ObstacleItemView viewPrefab)
        {
            _root = root;
            _viewPrefab = viewPrefab;

            _pool = new ObjectPool<ObstacleItemView>
            (
                CreateView,
                actionOnDestroy: DestroyView
            );
        }

        public IObstacleItemView GetView() => _pool.Get();

        public void ReleaseView(IObstacleItemView view)
        {
            if (view is ObstacleItemView castedView)
            {
                castedView.Visible = false;
                _pool.Release(castedView);
            }
        }

        private ObstacleItemView CreateView()
        {
            ObstacleItemView view = Object.Instantiate(_viewPrefab, _root, true);
            view.Visible = false;

            return view;
        }

        private void DestroyView(ObstacleItemView view)
        {
            Object.Destroy(view.gameObject);
        }
    }
}