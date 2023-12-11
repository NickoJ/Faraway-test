using NickoJ.DinoRunner.Core.Model;

namespace NickoJ.DinoRunner.Scripts.Background
{
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

        private void CurrentSpeedChangedHandler(float speed)
        {
            _view.MoveSpeed = speed;
        }
    }
}