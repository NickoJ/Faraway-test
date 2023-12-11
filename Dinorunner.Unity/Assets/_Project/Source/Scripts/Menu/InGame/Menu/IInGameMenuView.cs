using System;

namespace NickoJ.DinoRunner.Scripts.Menu.InGame.Menu
{
    /// <summary>
    /// InGameMenuViews' API.
    /// </summary>
    public interface IInGameMenuView
    {
        bool Visible { get; set; }

        public event Action OnJump;
    }
}