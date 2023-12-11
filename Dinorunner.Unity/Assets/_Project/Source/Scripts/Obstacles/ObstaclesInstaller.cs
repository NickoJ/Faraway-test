using NickoJ.DinoRunner.Core;
using NickoJ.DinoRunner.Core.Model;
using NickoJ.DinoRunner.Engine;
using UnityEngine;

namespace NickoJ.DinoRunner.Scripts.Obstacles
{
    /// <summary>
    /// Creates ObstaclesController using obstacle storage and model.
    /// </summary>
    public sealed class ObstaclesInstaller : Installer
    {
        [SerializeField] private ObstacleItemView obstacle;
        
        private ObstaclesController _obstaclesController;

        public override void Install(IServiceLocator serviceLocator)
        {
            IGameState state = serviceLocator.Get<IGame>().State;
            var storage = new ObstacleViewStorage(transform, obstacle);

            _obstaclesController = new ObstaclesController(state, storage);
        }
    }
}