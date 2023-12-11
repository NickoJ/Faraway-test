namespace NickoJ.DinoRunner.Scripts.Menu.Start.Score
{
    /// <summary>
    /// StartScoreViews' API
    /// </summary>
    public interface IStartScoreView
    {
        void UpdateScore(ulong bestScore, ulong newScore, bool newRecord);
    }
}