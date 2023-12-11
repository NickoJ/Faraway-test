using NickoJ.DinoRunner.Core;
using NickoJ.DinoRunner.Core.Model;
using NickoJ.DinoRunner.Engine;
using UnityEngine;

namespace NickoJ.DinoRunner.Scripts.Menu.InGame.Score
{
    public sealed class InGameScoreInstaller : Installer
    {
        [SerializeField] private InGameScoreView view;

        private InGameScoreController _controller;

        public override void Install(IServiceLocator serviceLocator)
        {
            IGameState state = serviceLocator.Get<IGame>().State;

            _controller = new InGameScoreController(view, state);
        }
    }
}