using System;

namespace NickoJ.DinoRunner.Scripts.Menu.InGame.Menu
{
    public interface IInGameMenuView
    {
        bool Visible { get; set; }

        public event Action OnJump;
    }
}