using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using NickoJ.DinoRunner.Core.GameSystems.Score;
using NickoJ.DinoRunner.Core.Model;

namespace NickoJ.DinoRunner.Scripts.Menu.InGame.Score
{
    /// <summary>
    /// Connects InGameScore view with model.
    /// </summary>
    public sealed class InGameScoreController
    {
        private readonly IInGameScoreView _view;
        private readonly IGameState _state;

        public InGameScoreController(IInGameScoreView view, IGameState state)
        {
            _view = view;
            _state = state;

            _state.OnGameStarted += GameStartedHandler;
        }

        private async void GameStartedHandler(bool started)
        {
            if (!started) return;

            GameScore score = _state.Score;
                
            await foreach (AsyncUnit _ in UniTaskAsyncEnumerable.EveryUpdate(PlayerLoopTiming.PreLateUpdate)
                               .TakeWhile(_ => _state.Started))
            {
                _view.UpdateScore(score.LastScore, score.LastScore > score.HighScore && score.HighScore > 0);
            }
        }
    }
}