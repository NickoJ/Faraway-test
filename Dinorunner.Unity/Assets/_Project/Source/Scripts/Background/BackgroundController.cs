using NickoJ.DinoRunner.Core.Model;

namespace NickoJ.DinoRunner.Scripts.Background
{
    /// <summary>
    /// Controller, responding for parallax of the background.
    /// </summary>
    public sealed class BackgroundController
    {
        private readonly Player _player;
        private readonly BackgroundView _view;

        public BackgroundController(Player player, BackgroundView view)
        {
            _player = player;
            _view = view;

            _player.OnCurrentSpeedChanged += CurrentSpeedChangedHandler;
            
            CurrentSpeedChangedHandler(player.CurrentSpeed);
        }

        /// <summary>
        /// Handles the OnCurrentSpeedChanged player's event to update the background
        /// view speed when the player's speed changes.
        /// </summary>
        /// <param name="speed"></param>
        private void CurrentSpeedChangedHandler(float speed)
        {
            _view.MoveSpeed = speed;
        }
    }
}