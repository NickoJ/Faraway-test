using NickoJ.DinoRunner.Core;
using NickoJ.DinoRunner.Core.Model;
using NickoJ.DinoRunner.Engine;
using UnityEngine;

namespace NickoJ.DinoRunner.Scripts.Dino
{
    /// <summary>
    /// Binds DinoController and DinoView
    /// </summary>
    public sealed class DinoInstaller : Installer
    {
        [SerializeField] private DinoView dinoView;

        private DinoController _controller;

        public override void Install(IServiceLocator serviceLocator)
        {
            Player player = serviceLocator.Get<IGame>().State.Player;

            _controller = new DinoController(dinoView, player);
        }
    }
}