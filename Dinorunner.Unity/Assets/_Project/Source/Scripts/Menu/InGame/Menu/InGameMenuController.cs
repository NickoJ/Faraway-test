using NickoJ.DinoRunner.Core;

namespace NickoJ.DinoRunner.Scripts.Menu.InGame.Menu
{
    public sealed class InGameMenuController
    {
        private readonly IGame _game;
        private readonly IInGameMenuView _view;

        public InGameMenuController(IGame game, IInGameMenuView view)
        {
            _game = game;
            _view = view;

            _game.State.OnGameStarted += GameStartedHandler;
            _view.OnJump += OnJumpHandler;

            GameStartedHandler(_game.State.Started);
        }

        private void OnJumpHandler()
        {
            _game.State.Player.Jump();
        }

        private void GameStartedHandler(bool started)
        {
            _view.Visible = started;
        }
    }
}