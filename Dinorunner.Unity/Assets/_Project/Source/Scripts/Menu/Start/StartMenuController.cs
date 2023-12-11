using NickoJ.DinoRunner.Core;

namespace NickoJ.DinoRunner.Scripts.Menu.Start
{
    public sealed class StartMenuController
    {
        private readonly IGame _game;
        private readonly IStartMenuView _view;

        public StartMenuController(IGame game, IStartMenuView view)
        {
            _game = game;
            _view = view;

            _game.State.OnGameStarted += GameStartedHandler;
            _view.OnStartButtonClicked += StartButtonClickedHandler;

            GameStartedHandler(_game.State.Started);
        }

        private void StartButtonClickedHandler()
        {
            _game.Start();
        }

        private void GameStartedHandler(bool started)
        {
            _view.Visible = !started;
        }
    }
}