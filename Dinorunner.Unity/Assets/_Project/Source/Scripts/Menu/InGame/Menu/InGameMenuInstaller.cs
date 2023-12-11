using NickoJ.DinoRunner.Core;
using NickoJ.DinoRunner.Engine;
using UnityEngine;

namespace NickoJ.DinoRunner.Scripts.Menu.InGame.Menu
{
    public sealed class InGameMenuInstaller : Installer
    {
        [SerializeField] private InGameMenuView view;

        private InGameMenuController _controller;
        
        public override void Install(IServiceLocator serviceLocator)
        {
            view.gameObject.SetActive(true);
            view.Visible = false;

            var game = serviceLocator.Get<IGame>();
            
            _controller = new InGameMenuController(game, view);
        }
    }
}
