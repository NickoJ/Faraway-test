using NickoJ.DinoRunner.Core;
using NickoJ.DinoRunner.Core.Model;
using NickoJ.DinoRunner.Engine;
using UnityEngine;

namespace NickoJ.DinoRunner.Scripts.Menu.Start.Score
{
    /// <summary>
    /// Creates StartScoreController using StartScoreView and required model.
    /// </summary>
    public sealed class StartScoreInstaller : Installer
    {
        [SerializeField] private StartScoreView view;

        private StartScoreController _controller;

        public override void Install(IServiceLocator serviceLocator)
        {
            IGameState state = serviceLocator.Get<IGame>().State;

            _controller = new StartScoreController(view, state.Score);
        }
    }
}