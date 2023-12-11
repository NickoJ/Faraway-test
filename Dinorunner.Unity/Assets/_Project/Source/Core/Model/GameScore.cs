using System;

namespace NickoJ.DinoRunner.Core.Model
{
    /// <summary>
    /// Contains information about scores.
    /// </summary>
    public sealed class GameScore
    {
        public ulong LastScore { get; private set; }
        public ulong HighScore { get; private set; }
        public bool Record { get; private set; }

        public event Action OnFinalScoreCalculated; 
        
        /// <summary>
        /// Remembers score during run.
        /// </summary>
        /// <param name="score"></param>
        public void OnLevelProgress(ulong score)
        {
            LastScore = score;
        }

        /// <summary>
        /// Detects if it's a new record or not after level is over.
        /// </summary>
        public void OnLevelFinished()
        {
            Record = LastScore > HighScore;
            HighScore = Math.Max(HighScore, LastScore);
            OnFinalScoreCalculated?.Invoke();
        }
    }
}