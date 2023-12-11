using System;

namespace NickoJ.DinoRunner.Scripts.Menu.Start.Menu
{
    /// <summary>
    /// StartMenuViews' API.
    /// </summary>
    public interface IStartMenuView
    {
        bool Visible { get; set; }

        public event Action OnStartButtonClicked;
    }
}