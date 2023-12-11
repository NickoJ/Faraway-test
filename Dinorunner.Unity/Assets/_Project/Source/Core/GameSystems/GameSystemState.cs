namespace NickoJ.DinoRunner.Core.GameSystems
{
    /// <summary>
    /// Game system possible internal state.
    /// </summary>
    public enum GameSystemState : byte
    {
        NotInitialized,
        Initialized,
        NeedToFinish,
        Finishing,
        Finished
    }
}