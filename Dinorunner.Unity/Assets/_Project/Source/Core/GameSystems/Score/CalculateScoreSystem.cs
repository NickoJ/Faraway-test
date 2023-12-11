using System;
using NickoJ.DinoRunner.Core.Model;

namespace NickoJ.DinoRunner.Core.GameSystems.Score
{
    /// <summary>
    /// System that calculates score during the run.
    /// </summary>
    internal sealed class CalculateScoreSystem : GameSystem, IInitGameSystem, IUpdateGameSystem, IFinishGameSystem
    {
        private readonly IGameState _state;

        private float _score;
        
        public CalculateScoreSystem(IGameState state) : base(false)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));

            _state.OnGameStarted += GameStartedHandler;
        }

        void IInitGameSystem.Init()
        {
            _score = 0;
            _state.Score.OnLevelProgress(0);
        }

        void IUpdateGameSystem.Update(float dt)
        {
            _score += _state.Player.CurrentSpeed * dt;
            var scoreDelta = (ulong) _score;
            _score -= scoreDelta;
            _state.Score.OnLevelProgress(_state.Score.LastScore + scoreDelta);
        }

        void IFinishGameSystem.Finish()
        {
            _state.Score.OnLevelFinished();
        }

        private void GameStartedHandler(bool started)
        {
            if (started)
            {
                Start();
            }
            else
            {
                Stop();
            }
        }
    }
}