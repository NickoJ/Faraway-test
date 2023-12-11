using NickoJ.DinoRunner.Core;
using NickoJ.DinoRunner.Core.Model;
using NickoJ.DinoRunner.Engine;
using UnityEngine;

namespace NickoJ.DinoRunner.Scripts.Background
{
    public class BackgroundInstaller : Installer
    {
        [SerializeField] private BackgroundView view;

        private BackgroundController _controller;

        public override void Install(IServiceLocator serviceLocator)
        {
            Player player = serviceLocator.Get<IGame>().State.Player;

            _controller = new BackgroundController(player, view);
        }
    }
}
