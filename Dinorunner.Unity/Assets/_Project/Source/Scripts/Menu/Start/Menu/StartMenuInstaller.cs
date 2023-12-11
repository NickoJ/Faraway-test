using NickoJ.DinoRunner.Core;
using NickoJ.DinoRunner.Engine;
using UnityEngine;

namespace NickoJ.DinoRunner.Scripts.Menu.Start.Menu
{
    /// <summary>
    /// Initializes StartMenuController with StartMenuView and required model.
    /// </summary>
    public sealed class StartMenuInstaller : Installer
    {
        [SerializeField] private StartMenuView view;

        private StartMenuController _controller;
        
        public override void Install(IServiceLocator serviceLocator)
        {
            view.gameObject.SetActive(true);
            view.Visible = false;

            var game = serviceLocator.Get<IGame>();
            
            _controller = new StartMenuController(game, view);
        }
    }
}
