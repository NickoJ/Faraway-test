using System;

namespace NickoJ.DinoRunner.Scripts.Menu.Start.Menu
{
    public interface IStartMenuView
    {
        bool Visible { get; set; }

        public event Action OnStartButtonClicked;
    }
}