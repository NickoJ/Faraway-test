namespace NickoJ.DinoRunner.Scripts.Menu.InGame.Score
{
    /// <summary>
    /// InGameScoreViews' API.
    /// </summary>
    public interface IInGameScoreView
    {
        void UpdateScore(ulong score, bool isRecord);
    }
}