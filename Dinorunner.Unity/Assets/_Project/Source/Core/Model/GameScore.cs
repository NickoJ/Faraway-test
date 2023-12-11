using System;

namespace NickoJ.DinoRunner.Core.GameSystems.Score
{
    public sealed class GameScore
    {
        public ulong LastScore { get; private set; }
        public ulong HighScore { get; private set; }
        public bool Record { get; private set; }

        public event Action OnFinalScoreCalculated; 
        
        public void OnLevelProgress(ulong score)
        {
            LastScore = score;
        }

        public void OnLevelFinished()
        {
            Record = LastScore > HighScore;
            HighScore = Math.Max(HighScore, LastScore);
            OnFinalScoreCalculated?.Invoke();
        }
    }
}