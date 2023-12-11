namespace NickoJ.DinoRunner.Scripts.Menu.InGame.Score
{
    public interface IInGameScoreView
    {
        void UpdateScore(ulong score, bool isRecord);
    }
}