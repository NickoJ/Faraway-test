namespace NickoJ.DinoRunner.Core
{
    public interface IGameLoop
    {
        public delegate void TickDelegate(float dt);
        
        event TickDelegate OnTick;
    }
}