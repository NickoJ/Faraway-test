using System;
using NickoJ.DinoRunner.Core.GameSystems.Score;

namespace NickoJ.DinoRunner.Scripts.Menu.Start.Score
{
    public sealed class StartScoreController
    {
        private readonly IStartScoreView _view;
        private readonly GameScore _score;

        public StartScoreController(IStartScoreView view, GameScore score)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _score = score ?? throw new ArgumentNullException(nameof(score));

            _score.OnFinalScoreCalculated += FinalScoreCalculatedHandler;
        }

        private void FinalScoreCalculatedHandler()
        {
            _view.UpdateScore(_score.HighScore, _score.LastScore, _score.Record);
        }
    }
}