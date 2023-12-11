using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using NickoJ.DinoRunner.Core.GameSystems.Score;
using NickoJ.DinoRunner.Core.Model;

namespace NickoJ.DinoRunner.Scripts.Menu.InGame.Score
{
    public sealed class InGameScoreController
    {
        private readonly IInGameScoreView _view;
        private readonly IGameState _state;

        private CancellationTokenSource _cancellation;
        
        public InGameScoreController(IInGameScoreView view, IGameState state)
        {
            _view = view;
            _state = state;

            _state.OnGameStarted += GameStartedHandler;
        }

        private async void GameStartedHandler(bool started)
        {
            if (started)
            {
                _cancellation = new CancellationTokenSource();

                GameScore score = _state.Score;
                
                await foreach (AsyncUnit _ in UniTaskAsyncEnumerable.EveryUpdate(PlayerLoopTiming.PreLateUpdate).WithCancellation(_cancellation.Token))
                {
                    _view.UpdateScore(score.LastScore, score.LastScore > score.HighScore && score.HighScore > 0);
                }
            }
            else if (_cancellation != null)
            {
                _cancellation.Cancel();
                _cancellation.Dispose();
            }
        }
    }
}