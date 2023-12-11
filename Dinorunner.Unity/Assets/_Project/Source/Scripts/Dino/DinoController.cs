using System;
using NickoJ.DinoRunner.Core.Model;

namespace NickoJ.DinoRunner.Scripts.Dino
{
    /// <summary>
    /// Setup dino view according to model data.
    /// </summary>
    public sealed class DinoController
    {
        private readonly IDinoView _dinoView;
        private readonly Player _player;

        public DinoController(IDinoView dinoView, Player player)
        {
            _dinoView = dinoView ?? throw new ArgumentNullException(nameof(dinoView));
            _player = player ?? throw new ArgumentNullException(nameof(player));

            _dinoView.OnUpdate += ViewUpdateHandler;

            ViewUpdateHandler();
        }

        private void ViewUpdateHandler()
        {
            _dinoView.UpdateView(_player.CurrentSpeed, _player.Y, _player.IsFlying);
        }
    }
}