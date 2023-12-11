namespace NickoJ.DinoRunner.Scripts.Menu.Start.Score
{
    public interface IStartScoreView
    {
        void UpdateScore(ulong bestScore, ulong newScore, bool newRecord);
    }
}